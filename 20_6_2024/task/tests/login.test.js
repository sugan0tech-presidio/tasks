const { JSDOM } = require('jsdom');

describe('Login Functionality', () => {
    let dom;
    let document;

    beforeEach(() => {
    // login html
        dom = new JSDOM(`
            <!DOCTYPE html>
            <html lang="en">
            <head>
                <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <title>Login Page</title>
            </head>
            <body>
                <div class="login-container">
                    <h2>Login</h2>
                    <form id="login-form">
                        <label for="username">Username:</label>
                        <input type="text" id="username" name="username" required>
                        <label for="password">Password:</label>
                        <input type="password" id="password" name="password" required>
                        <button type="button" id="login-btn">Login</button>
                        <p id="login-message"></p>
                    </form>
                </div>
                <script>
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
                </script>
            </body>
            </html>
        `, { runScripts: 'dangerously', resources: 'usable' });

        document = dom.window.document;
    });

    test('Successful login', () => {
        document.getElementById('username').value = 'user1';
        document.getElementById('password').value = 'password1';

        document.getElementById('login-btn').click();

        expect(document.getElementById('login-message').textContent).toBe('Login successful!');
        expect(document.getElementById('login-message').style.color).toBe('green');
    });

    test('wrong login with incorrect password', () => {
        document.getElementById('username').value = 'user1';
        document.getElementById('password').value = 'wrongpassword';

        document.getElementById('login-btn').click();

        expect(document.getElementById('login-message').textContent).toBe('Invalid username or password!');
        expect(document.getElementById('login-message').style.color).toBe('red');
    });

    test('wrong login with incorrect username', () => {
        document.getElementById('username').value = 'wronguser';
        document.getElementById('password').value = 'password1';

        document.getElementById('login-btn').click();

        expect(document.getElementById('login-message').textContent).toBe('Invalid username or password!');
        expect(document.getElementById('login-message').style.color).toBe('red');
    });

    test('wrong login with empty fields', () => {
        document.getElementById('username').value = '';
        document.getElementById('password').value = '';

        document.getElementById('login-btn').click();

        expect(document.getElementById('login-message').textContent).toBe('Invalid username or password!');
        expect(document.getElementById('login-message').style.color).toBe('red');
    });
});

test('button click', () => {
    const dom = new JSDOM(`
        <!DOCTYPE html>
        <html>
            <body>
                <button id="btn">Click me</button>
                <p id="demo"></p>
                <script>
                    document.getElementById('btn').addEventListener('click', () => {
                        document.getElementById('demo').innerHTML = 'Hello World';
                    });
                </script>
            </body>
        </html>`, { runScripts: 'dangerously', resources: 'usable' });

    dom.window.document.getElementById('btn').click();
    const actual = dom.window.document.getElementById('demo').innerHTML;
    expect(actual).toBe('Hello World');
});

