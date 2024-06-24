document.addEventListener('DOMContentLoaded', function () {
    var toggleButtons = document.querySelectorAll('.toggle-btn');

    toggleButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            var card = this.closest('.card');
            var cardDetails = card.querySelector('.card-details');

            if (cardDetails.style.display === 'none' || cardDetails.style.display === '') {
                cardDetails.style.display = 'block';
                this.textContent = '折疊';
            } else {
                cardDetails.style.display = 'none';
                this.textContent = '展開';
            }
        });
    });

    // Add event listeners for the filter inputs
    document.getElementById('nameFilter').addEventListener('input', filterHeroes);
    document.getElementById('titleFilter').addEventListener('input', filterHeroes);
    document.getElementById('attributeFilter').addEventListener('input', filterHeroes);

    function filterHeroes() {
        var nameFilter = document.getElementById('nameFilter').value.toLowerCase();
        var titleFilter = document.getElementById('titleFilter').value.toLowerCase();
        var attributeFilter = document.getElementById('attributeFilter').value.toLowerCase();

        var heroCards = document.querySelectorAll('.hero-card');

        heroCards.forEach(function (card) {
            var name = card.dataset.name.toLowerCase();
            var title = card.dataset.title.toLowerCase();
            var attribute = card.dataset.attribute.toLowerCase();

            if (name.includes(nameFilter) && title.includes(titleFilter) && attribute.includes(attributeFilter)) {
                card.style.display = 'block';
            } else {
                card.style.display = 'none';
            }
        });
    }
});
