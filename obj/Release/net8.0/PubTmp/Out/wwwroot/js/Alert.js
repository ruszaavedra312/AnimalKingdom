// Deletion Alert
function confirmDelete(animalId) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to undo this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            document.getElementById("deleteForm-" + animalId).submit();
        }
    });
}

// Alert Message for Success Insertion of Data
document.addEventListener("DOMContentLoaded", function () {
    let successMessageElement = document.getElementById("successMessage");

    if (successMessageElement) {
        let message = successMessageElement.getAttribute("data-message");
        if (message) {
            Swal.fire({
                title: "Success!",
                text: message,
                icon: "success",
                confirmButtonColor: "#3085d6",
                confirmButtonText: "OK"
            });
        }
    }
});


// Alert Message for Updating Date
document.addEventListener("DOMContentLoaded", function () {
    let successMessageElement = document.getElementById("successMessageUpdate");

    if (successMessageElement) {
        let message = successMessageElement.getAttribute("data-message");
        if (message) {
            Swal.fire({
                title: "Success!",
                text: message,  // Use the value from the hidden div
                icon: "success",
                confirmButtonColor: "#3085d6",
                confirmButtonText: "OK"
            });
        }
    }
});

