document.addEventListener('DOMContentLoaded', populateEditForm);

function populateEditForm() {
    const urlParams = new URLSearchParams(window.location.search);
    const userId = urlParams.get('id');

    fetch(`https://localhost:44335/api/RandomUser/GetRandomUserById/${userId}`)
        .then(response => response.json())
        .then(user => {
            document.querySelector('#editUserId').value = user.id;
            document.querySelector('#editGender').value = user.gender;
            document.querySelector('#editTitle').value = user.nameTitle;
            document.querySelector('#editFirstName').value = user.nameFirst;
            document.querySelector('#editLastName').value = user.nameLast;
            document.querySelector('#editStreetNumber').value = user.streetNumber;
            document.querySelector('#editStreetName').value = user.streetName;
            document.querySelector('#editCity').value = user.city;
            document.querySelector('#editState').value = user.state;
            document.querySelector('#editCountry').value = user.country;
            document.querySelector('#editPostcode').value = user.postcode;
            document.querySelector('#editEmail').value = user.email;
            document.querySelector('#editUsername').value = user.username;
            document.querySelector('#editPassword').value = user.password;
            document.querySelector('#editDobDate').value = new Date(user.dobDate).toLocaleDateString()
            document.querySelector('#editDobAge').value = user.dobAge;
            document.querySelector('#editPhone').value = user.phone;
            document.querySelector('#editCell').value = user.cell;
            document.querySelector('#editNat').value = user.nat;
        });
}


function saveUser() {
    const userId = document.querySelector('#editUserId').value;

    
    const userData = {
        id: userId,
        gender: document.querySelector('#editGender').value,
        nameTitle: document.querySelector('#editTitle').value,
        nameFirst: document.querySelector('#editFirstName').value,
        nameLast: document.querySelector('#editLastName').value,
        dobAge: parseInt(document.querySelector('#editDobAge').value),
        streetNumber: parseInt(document.querySelector('#editStreetNumber').value),
        streetName: document.querySelector('#editStreetName').value,
        city: document.querySelector('#editCity').value,
        state: document.querySelector('#editState').value,
        country: document.querySelector('#editCountry').value,
        postcode: document.querySelector('#editPostcode').value,
        email: document.querySelector('#editEmail').value,
        loginUsername: document.querySelector('#editUsername').value,
        loginPassword: document.querySelector('#editPassword').value,
        phone: document.querySelector('#editPhone').value,
        cell: document.querySelector('#editCell').value,
        nat: document.querySelector('#editNat').value
    };

    fetch(`https://localhost:44335/api/RandomUser/Edit/${userId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
    })
    .then(response => {
        if (response.ok) {
            alert('User updated successfully');
            window.location.href = 'index.html'; 
        } else {
            alert('Failed to update user');
        }
    }).catch(error => {
        console.log(error)
    })
}