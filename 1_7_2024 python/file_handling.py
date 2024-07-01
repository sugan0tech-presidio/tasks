def append_content(filename):
    with open(filename, "a") as file:
        file.write("This is a new line appended to the file.\n")
        file.write("Appending another line to the file.\n")
    print("Content appended to the file.")

def override_content(filename):
    with open(filename, "w") as file:
        file.write("This content will override the existing content.\n")
        file.write("All previous content has been cleared and replaced.\n")
    print("Content overridden in the file.")

def read_content(filename):
    with open(filename, "r") as file:
        for line in file:
            print(line.strip())
    print("Content read from the file.")

def file_operations(action, filename):
    switcher = {
        "append": append_content,
        "override": override_content,
        "read": read_content
    }
    
    func = switcher.get(action)
    
    if func:
        func(filename)
    else:
        print("Invalid action. Please choose from 'append', 'override', or 'read'.")

# Test the switch statement with different actions
filename = "./file.txt"

file_operations("append", filename)
file_operations("override", filename)
file_operations("read", filename)
#                          ^
#                           a -> append mode
#                           r -> read mode
