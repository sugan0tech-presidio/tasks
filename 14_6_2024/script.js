// Preloaded profession list
let professionList = ["Developer", "Designer", "Manager", "Teacher"];
const professionInput = document.getElementById('profession');
const professionDatalist = document.getElementById('professionList');

// Load initial professions into the datalist
function loadProfessions() {
    professionDatalist.innerHTML = "";
    professionList.forEach(profession => {
        let option = document.createElement('option');
        option.value = profession;
        professionDatalist.appendChild(option);
    });
}

// Validate form fields
function validateForm() {
    let errors = [];

    // Validate name
    const name = document.getElementById('name');
    if (name.value.trim() === "") {
        errors.push("Name is required.");
        name.classList.add('error');
        document.getElementById('nameError').innerText = "Name is required.";
    } else {
        name.classList.remove('error');
        document.getElementById('nameError').innerText = "";
    }

    // Validate phone
    const phone = document.getElementById('phone');
    const phoneRegex = /^[0-9]{10}$/;
    if (!phoneRegex.test(phone.value)) {
        errors.push("Valid phone number is required.");
        phone.classList.add('error');
        document.getElementById('phoneError').innerText = "Valid phone number is required.";
    } else {
        phone.classList.remove('error');
        document.getElementById('phoneError').innerText = "";
    }

    // Validate DOB and calculate age
    const dob = document.getElementById('dob');
    const age = document.getElementById('age');
    if (dob.value === "") {
        errors.push("Date of Birth is required.");
        dob.classList.add('error');
        document.getElementById('dobError').innerText = "Date of Birth is required.";
    } else {
        dob.classList.remove('error');
        document.getElementById('dobError').innerText = "";
        
        const birthDate = new Date(dob.value);
        const today = new Date();
        const ageValue = today.getFullYear() - birthDate.getFullYear();
        const m = today.getMonth() - birthDate.getMonth();
        
        // Adjust age if birth month is not yet reached in the current year
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age.value = ageValue - 1;
        } else {
            age.value = ageValue;
        }

        // Check age constraints
        if (age.value < 18) {
            errors.push("Age must be 18 or older.");
            dob.classList.add('error');
            document.getElementById('dobError').innerText = "Age must be 18 or older.";
        } else if (age.value > 150) {
            errors.push("Age must be less than 150.");
            dob.classList.add('error');
            document.getElementById('dobError').innerText = "Age must be less than 150.";
        } else {
            dob.classList.remove('error');
            document.getElementById('dobError').innerText = "";
        }
    }

    // Validate email
    const email = document.getElementById('email');
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email.value)) {
        errors.push("Valid email is required.");
        email.classList.add('error');
        document.getElementById('emailError').innerText = "Valid email is required.";
    } else {
        email.classList.remove('error');
        document.getElementById('emailError').innerText = "";
    }

    // Validate gender
    const gender = document.querySelector('input[name="gender"]:checked');
    if (!gender) {
        errors.push("Gender is required.");
        document.getElementById('genderError').innerText = "Gender is required.";
    } else {
        document.getElementById('genderError').innerText = "";
    }

    // Validate qualification
    const qualifications = document.querySelectorAll('input[name="qualification"]:checked');
    if (qualifications.length === 0) {
        errors.push("At least one qualification is required.");
        document.getElementById('qualificationError').innerText = "At least one qualification is required.";
    } else {
        document.getElementById('qualificationError').innerText = "";
    }

    // Validate profession
    const profession = document.getElementById('profession');
    if (profession.value.trim() === "") {
        errors.push("Profession is required.");
        profession.classList.add('error');
        document.getElementById('professionError').innerText = "Profession is required.";
    } else {
        profession.classList.remove('error');
        document.getElementById('professionError').innerText = "";

        // Add new profession to the list if not already present
        if (!professionList.includes(profession.value)) {
            professionList.push(profession.value);
            loadProfessions();
        }
    }

    // Display consolidated errors
    const formErrors = document.getElementById('formErrors');
    if (errors.length > 0) {
        formErrors.innerHTML = errors.join('<br>');
    } else {
        formErrors.innerHTML = "Form submitted successfully!";
    }
}

// Event listeners for validation on blur
document.getElementById('name').addEventListener('blur', validateForm);
document.getElementById('phone').addEventListener('blur', validateForm);
document.getElementById('dob').addEventListener('blur', validateForm);
document.getElementById('email').addEventListener('blur', validateForm);
document.getElementById('profession').addEventListener('blur', validateForm);

// Load initial professions
loadProfessions();

