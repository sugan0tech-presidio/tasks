document.addEventListener('DOMContentLoaded', checkAuthForPage);

function isAuthenticated() {
    // return localStorage.getItem('isAuthenticated') === 'true';
    return true;
}

function requireAuth() {
    if (!isAuthenticated()) {
        window.location.href = 'login.html';
    }
}

function login() {
    localStorage.setItem('isAuthenticated', 'true');
    window.location.href = 'index.html';
}

function logout() {
    localStorage.setItem('isAuthenticated', 'false');
    window.location.href = 'login.html';
}

function checkAuthForPage() {
    if (!isAuthenticated() && !window.location.href.includes('login.html') && !window.location.href.includes('register.html')) {
        window.location.href = 'login.html';
    }
}

function toggleChatWindow() {
    const chatBody = document.getElementById('chatBody');
    if (chatBody.style.display === 'none' || chatBody.style.display === '') {
        chatBody.style.display = 'block';
    } else {
        chatBody.style.display = 'none';
    }
}

function sendMessage() {
    const chatInput = document.getElementById('chatInput');
    const chatMessages = document.getElementById('chatMessages');
    const messageText = chatInput.value.trim();

    if (messageText) {
        const messageElement = document.createElement('div');
        messageElement.className = 'message message-sent';
        messageElement.textContent = messageText;
        chatMessages.appendChild(messageElement);
        chatMessages.scrollTop = chatMessages.scrollHeight;

        chatInput.value = '';

        setTimeout(() => {
            const replyElement = document.createElement('div');
            replyElement.className = 'message message-received';
            replyElement.textContent = "Reply: " + messageText;
            chatMessages.appendChild(replyElement);
            chatMessages.scrollTop = chatMessages.scrollHeight;
        }, 1000);
    }
}
