const validUsers = [
    { username: 'user1', password: 'password1' },
    { username: 'user2', password: 'password2' }
];

document.getElementById('login-btn').addEventListener('click', () => {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    const user = validUsers.find(user => user.username === username && user.password === password);

    const message = document.getElementById('login-message');
    if (user) {
        message.textContent = 'Login successful!';
        message.style.color = 'green';
    } else {
        message.textContent = 'Invalid username or password!';
        message.style.color = 'red';
    }
});

