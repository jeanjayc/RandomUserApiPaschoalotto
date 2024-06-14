function getUserRandom() {
    let tableBody = document.querySelector('#userData');
    fetch('https://localhost:44335/api/RandomUser/GetAllRandomUser')
        .then(response => response.json())
        .then(data => {
            data.forEach(user => {
                const row = document.createElement('tr');

                row.innerHTML = `
                <td>${user.gender}</td>
                <td>${user.nameLast}</td>
                <td>${user.nameFirst}</td>
                <td>${user.nnameLast}</td>
                <td>${user.streetNumber}</td>
                <td>${user.streetName}</td>
                <td>${user.city}</td>
                <td>${user.state}</td>
                <td>${user.country}</td>
                <td>${user.postcode}</td>
                <td>${user.latitude}</td>
                <td>${user.longitude}</td>
                <td>${user.offset}</td>
                <td>${user.description}</td>
                <td>${user.email}</td>
                <td>${user.loginUuid}</td>
                <td>${user.loginUsername}</td>
                <td>${user.loginPassword}</td>
                <td>${user.loginSalt}</td>
                <td>${user.loginMd5}</td>
                <td>${user.loginSha1}</td>
                <td>${user.loginSha256}</td>
                <td>${new Date(user.dobDate).toLocaleDateString()}</td>
                <td>${user.dobAge}</td>
                <td>${new Date(user.registeredDate).toLocaleDateString()}</td>
                <td>${user.registeredAge}</td>
                <td>${user.phone}</td>
                <td>${user.cell}</td>
                <td>${user.idName}</td>
                <td>${user.idValue}</td>
                <td><img src="${user.pictureLarge}" alt="Large Picture" width="50"/></td>
                <td><img src="${user.pictureMedium}" alt="Medium Picture" width="50"/></td>
                <td><img src="${user.pictureThumbnail}" alt="Thumbnail" width="50"/></td>
                <td>${user.nat}</td>
            `;

            tableBody.appendChild(row);
            })
        })
}