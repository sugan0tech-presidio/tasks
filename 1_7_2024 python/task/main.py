import re
from datetime import datetime
import pandas as pd
import openpyxl
from fpdf import FPDF

# Function to validate email
def is_valid_email(email):
    pattern = r"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
    return re.match(pattern, email)

# Function to validate phone number
def is_valid_phone(phone):
    pattern = r"^\d{10}$"
    return re.match(pattern, phone)

# Function to validate date of birth and calculate age
def calculate_age(dob):
    try:
        dob = datetime.strptime(dob, "%Y-%m-%d")
        today = datetime.today()
        age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
        return age
    except ValueError:
        return None

# Function to take employee details from console
def get_employee_details():
    while True:
        name = input("Enter Name: ")
        dob = input("Enter Date of Birth (YYYY-MM-DD): ")
        phone = input("Enter Phone Number: ")
        email = input("Enter E-Mail: ")

        if not is_valid_email(email):
            print("Invalid email format. Please try again.")
            continue
        
        if not is_valid_phone(phone):
            print("Invalid phone number. Please enter a 10-digit phone number.")
            continue
        
        age = calculate_age(dob)
        if age is None:
            print("Invalid date of birth. Please use YYYY-MM-DD format.")
            continue
        
        break
    
    return {"Name": name, "DOB": dob, "Phone": phone, "Email": email, "Age": age}

# Function to save data in text format
def save_to_text(employee_list):
    with open("employees.txt", "w") as file:
        for employee in employee_list:
            file.write(f"Name: {employee['Name']}\n")
            file.write(f"Date of Birth: {employee['DOB']}\n")
            file.write(f"Phone: {employee['Phone']}\n")
            file.write(f"Email: {employee['Email']}\n")
            file.write(f"Age: {employee['Age']}\n\n")

# Function to save data in Excel format
def save_to_excel(employee_list):
    df = pd.DataFrame(employee_list)
    df.to_excel("employees.xlsx", index=False)

# Function to save data in PDF format
def save_to_pdf(employee_list):
    pdf = FPDF()
    pdf.add_page()
    pdf.set_font("Arial", size=12)

    for employee in employee_list:
        pdf.cell(200, 10, txt=f"Name: {employee['Name']}", ln=True)
        pdf.cell(200, 10, txt=f"DOB: {employee['DOB']}", ln=True)
        pdf.cell(200, 10, txt=f"Phone: {employee['Phone']}", ln=True)
        pdf.cell(200, 10, txt=f"Email: {employee['Email']}", ln=True)
        pdf.cell(200, 10, txt=f"Age: {employee['Age']}", ln=True)
        pdf.ln(10)  # Add a line break

    pdf.output("employees.pdf")

# Function to read employee details from Excel file
def read_from_excel(filename):
    df = pd.read_excel(filename)
    employees = df.to_dict(orient='records')
    return employees

# Main menu function
def main_menu():
    employee_list = []

    while True:
        print("\n1. Add Employee")
        print("2. Save Data")
        print("3. Bulk Read from Excel")
        print("4. Exit")

        choice = input("Choose an option: ")

        if choice == "1":
            employee = get_employee_details()
            employee_list.append(employee)
        elif choice == "2":
            print("\nChoose a format to save:")
            print("1. Text")
            print("2. Excel")
            print("3. PDF")
            save_choice = input("Choose an option: ")

            if save_choice == "1":
                save_to_text(employee_list)
                print("Data saved to employees.txt")
            elif save_choice == "2":
                save_to_excel(employee_list)
                print("Data saved to employees.xlsx")
            elif save_choice == "3":
                save_to_pdf(employee_list)
                print("Data saved to employees.pdf")
            else:
                print("Invalid option.")
        elif choice == "3":
            filename = input("Enter Excel file path: ")
            employees = read_from_excel(filename)
            employee_list.extend(employees)
            print(f"{len(employees)} employees read from {filename}")
        elif choice == "4":
            break
        else:
            print("Invalid option.")

if __name__ == "__main__":
    main_menu()
