const quotesContainer = document.getElementById('quotes-container');
const prevButton = document.getElementById('prev');
const nextButton = document.getElementById('next');
let currentPage = 1;
const quotesPerPage = 5;

const fetchQuotes = async (page) => {
    const response = await fetch(`https://dummyjson.com/quotes?skip=${(page - 1) * quotesPerPage}&limit=${quotesPerPage}`);
    const data = await response.json();
    return data.quotes;
};

const renderQuotes = (quotes) => {
    quotesContainer.innerHTML = '';
    quotes.forEach(quote => {
        const quoteElement = document.createElement('div');
        quoteElement.classList.add('quote');
        quoteElement.innerHTML = `<p>"${quote.quote}"</p><p>- ${quote.author}</p>`;
        quotesContainer.appendChild(quoteElement);
    });
};

const updatePaginationButtons = async () => {
    const response = await fetch('https://dummyjson.com/quotes');
    const data = await response.json();
    const totalQuotes = data.total;

    if (currentPage === 1) {
        prevButton.disabled = true;
    } else {
        prevButton.disabled = false;
    }

    if (currentPage * quotesPerPage >= totalQuotes) {
        nextButton.disabled = true;
    } else {
        nextButton.disabled = false;
    }
};

const loadQuotes = async (page) => {
    const quotes = await fetchQuotes(page);
    renderQuotes(quotes);
    updatePaginationButtons();
};

prevButton.addEventListener('click', () => {
    if (currentPage > 1) {
        currentPage--;
        loadQuotes(currentPage);
    }
});

nextButton.addEventListener('click', () => {
    currentPage++;
    loadQuotes(currentPage);
});

// Initial
loadQuotes(currentPage);

