  document.addEventListener('DOMContentLoaded', function () {
    const gallery = document.querySelector('.pokemon-gallery');
    const loadMoreBtn = document.getElementById('load-more');
    let offset = 0;
    let pokemonData = [];

    

    async function fetchPokemon(offset) {
        try {
            const response = await fetch(`https://pokeapi.co/api/v2/pokemon?offset=${offset}&limit=20`);
            const data = await response.json();
            return data.results;
        } catch (error) {
            console.error('Error fetching Pokemon:', error);

        }

    }



    async function displayPokemonGallery() {
        const pokemonList = await fetchPokemon(offset);
        pokemonData.push(...pokemonList);
        pokemonList.forEach(pokemon => {
            const pokemonCard = document.createElement('div');
            pokemonCard.classList.add('pokemon-card');
            pokemonCard.dataset.id = parseUrl(pokemon.url);
            pokemonCard.innerHTML = `
                <img src="https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/${parseUrl(pokemon.url)}.png" alt="${pokemon.name}">
                <p>${capitalizeFirstLetter(pokemon.name)}</p>
            `;
            gallery.appendChild(pokemonCard);
            pokemonCard.addEventListener('click', () => displayPokemonDetails(pokemon, pokemonCard));


        });
        
    }

    async function displayPokemonDetails(pokemon, pokemonCard) {
        try {
            const response = await fetch(`https://pokeapi.co/api/v2/pokemon/${pokemon.name}`);
            const data = await response.json();
            const modalContent = `
                <div class="modal">
                    <div class="modal-content">
                        <span class="close">&times;</span>
                        <img src="https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/${parseUrl(pokemon.url)}.png" alt="${pokemon.name}">
                        <p>Name: ${capitalizeFirstLetter(pokemon.name)}</p>
                        <p>Abilities: ${data.abilities.map(ability => ability.ability.name).join(', ')}</p>
                        <p>Types: ${data.types.map(type => type.type.name).join(', ')}</p>
                        <button class="catch-btn" data-id="${pokemon.url}">${isPokemonCaught(pokemon) ? 'Release' : 'Catch'}</button>
                    </div>
                </div>
            `;


            document.body.insertAdjacentHTML('beforeend', modalContent); 
            const closeModalBtn = document.querySelector('.close');
            closeModalBtn.addEventListener('click', () => {
                const modal = document.querySelector('.modal');
                modal.parentElement.removeChild(modal);


            });


            const catchBtn = document.querySelector('.catch-btn');
            catchBtn.addEventListener('click', () => {
                if (!isPokemonCaught(pokemon)) {
                    catchPokemon(pokemon);
                    catchBtn.textContent = 'Release';
                    pokemonCard.classList.add('caught');
                } else {
                    releasePokemon(pokemon);
                    catchBtn.textContent = 'Catch';
                    pokemonCard.classList.remove('caught');
                }


            });


        } 
        catch (error) {
            console.error('Error fetching Pokemon details:', error);

        }
    }

    function isPokemonCaught(pokemon) {
        const caughtPokemon = JSON.parse(localStorage.getItem('caughtPokemon')) || [];
        return caughtPokemon.includes(pokemon.url);

    }


    function catchPokemon(pokemon) {
        const caughtPokemon = JSON.parse(localStorage.getItem('caughtPokemon')) || [];
        caughtPokemon.push(pokemon.url);
        localStorage.setItem('caughtPokemon', JSON.stringify(caughtPokemon));

    }



    function releasePokemon(pokemon) {
        const caughtPokemon = JSON.parse(localStorage.getItem('caughtPokemon')) || [];
        const updatedCaughtPokemon = caughtPokemon.filter(p => p !== pokemon.url);
        localStorage.setItem('caughtPokemon', JSON.stringify(updatedCaughtPokemon));


    }



    function loadMorePokemon() {
        offset += 20;
        displayPokemonGallery();
    }



    function parseUrl(url) {
        return url.substring(url.substring(0, url.length - 1).lastIndexOf('/') + 1, url.length - 1);
    }


    function capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);


    }

    loadMoreBtn.addEventListener('click', loadMorePokemon);
    displayPokemonGallery();


  });
