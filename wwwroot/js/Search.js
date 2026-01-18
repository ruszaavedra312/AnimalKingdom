// Searching Available Data
document.addEventListener("DOMContentLoaded", function () {
    let searchInput = document.getElementById("searchInput");

    searchInput.addEventListener("keyup", function () {
        let filter = searchInput.value.toLowerCase();
        let tableRows = document.querySelectorAll("#animalTable tbody tr");

        tableRows.forEach(row => {
            let name = row.querySelector(".name").textContent.toLowerCase();
            let species = row.querySelector(".species").textContent.toLowerCase();
            let caretaker = row.querySelector(".caretaker").textContent.toLowerCase();
            // let originatedPlace = row.querySelector(".originatedPlace").textContent.toLowerasCe();
            // let originalOwner = row.querySelector(".originalOwner").textContent.toLowerCase();

            if (name.includes(filter) || species.includes(filter) || caretaker.includes(filter) /*|| originatedPlace.includes(filter) || originalOwner.includes(filter)*/) {
                row.style.display = "";
            } else {
                row.style.display = "none";
            }
        });
    });
});
