const quotesContainer = document.getElementById('quotes-container');
const prevButton = document.getElementById('prev');
const nextButton = document.getElementById('next');
const searchInput = document.getElementById('searchInput');
const sortAscButton = document.getElementById('sortAsc');
const sortDescButton = document.getElementById('sortDesc');
let currentPage = 1;
const quotesPerPage = 5;
let allQuotes = [];  // To store all quotes for search and sorting
let displayedQuotes = [];  // To store currently displayed quotes

const fetchQuotes = async () => {
    const response = await fetch('https://dummyjson.com/quotes?limit=1454');
    const data = await response.json();
    return data.quotes;
};

const filterAndSortQuotes = (quotes, searchQuery, sortDirection) => {
    console.log(quotes)
    let filteredQuotes = quotes.filter(quote => quote.author.toLowerCase().includes(searchQuery.toLowerCase()));
    if (sortDirection === 'asc') {
        filteredQuotes.sort((a, b) => a.quote.localeCompare(b.quote));
    } else if (sortDirection === 'desc') {
        filteredQuotes.sort((a, b) => b.quote.localeCompare(a.quote));
    }
    return filteredQuotes;
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

const updatePaginationButtons = () => {
    prevButton.disabled = currentPage === 1;
    nextButton.disabled = currentPage * quotesPerPage >= displayedQuotes.length;
};

const loadQuotes = (page, searchQuery = '', sortDirection = '') => {
    const start = (page - 1) * quotesPerPage;
    const end = page * quotesPerPage;
    displayedQuotes = filterAndSortQuotes(allQuotes, searchQuery, sortDirection);
    const quotesToDisplay = displayedQuotes.slice(start, end);
    renderQuotes(quotesToDisplay);
    updatePaginationButtons();
};

searchInput.addEventListener('input', () => {
    currentPage = 1;
    loadQuotes(currentPage, searchInput.value, sortAscButton.classList.contains('active') ? 'asc' : 'desc');
});

sortAscButton.addEventListener('click', () => {
    sortAscButton.classList.add('active');
    sortDescButton.classList.remove('active');
    loadQuotes(currentPage, searchInput.value, 'asc');
});

sortDescButton.addEventListener('click', () => {
    sortAscButton.classList.remove('active');
    sortDescButton.classList.add('active');
    loadQuotes(currentPage, searchInput.value, 'desc');
});

prevButton.addEventListener('click', () => {
    if (currentPage > 1) {
        currentPage--;
        loadQuotes(currentPage, searchInput.value, sortAscButton.classList.contains('active') ? 'asc' : 'desc');
    }
});

nextButton.addEventListener('click', () => {
    if (currentPage * quotesPerPage < displayedQuotes.length) {
        currentPage++;
        loadQuotes(currentPage, searchInput.value, sortAscButton.classList.contains('active') ? 'asc' : 'desc');
    }
});

// Initial load
fetchQuotes().then(quotes => {
    allQuotes = quotes;
    loadQuotes(currentPage);
});

