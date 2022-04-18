const offerUri = 'api/offers';
const priceUri = 'api/price';

function calculatePrice() {
    const distanceTextbox = document.getElementById('distance');
    const livingSpaceTextbox = document.getElementById('living-space');
    const storageSpaceTextbox = document.getElementById('storage-space');
    const heavyItemCheckBox = document.getElementById('heavy-item');

    const model = {     
            Distance: parseInt(distanceTextbox.value.trim()),
            LivingSpace: parseInt(livingSpaceTextbox.value.trim()),
            StorageSpace: parseInt(storageSpaceTextbox.value.trim()),
            HasHeavyItem: heavyItemCheckBox.checked   
    };

    fetch(priceUri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(model)
    })
        .then(response => response.json())
        .then(data => {
            _displayPrice(data);
        })
        .catch(error => console.error('An error occurred, price can not be calculated.', error));
}


function requestOffer() {
    const firstNameTextbox = document.getElementById('first-name');
    const lastNameTextbox = document.getElementById('last-name');
    const emailTextbox = document.getElementById('email');
    const fromAddressTextbox = document.getElementById('from-address');
    const toAddressTextbox = document.getElementById('to-address');
    const distanceTextbox = document.getElementById('distance');
    const livingSpaceTextbox = document.getElementById('living-space');
    const storageSpaceTextbox = document.getElementById('storage-space');
    const heavyItemCheckBox = document.getElementById('heavy-item');
    const priceContainer = document.getElementById('price');

    const model = {
        FirstName: firstNameTextbox.value.trim(),
        LastName: lastNameTextbox.value.trim(),
        Email: emailTextbox.value.trim(),
        Offers: [
            {
                FromAddress: fromAddressTextbox.value.trim(),
                ToAddress: toAddressTextbox.value.trim(),
                Distance: parseInt(distanceTextbox.value.trim()),
                LivingSpace: parseInt(livingSpaceTextbox.value.trim()),
                StorageSpace: parseInt(storageSpaceTextbox.value.trim()),
                HeavyItem: heavyItemCheckBox.checked,
                OfferPrice: calculatePrice(),
            }
        ]
    }

    fetch(offerUri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(model)
    })
        .then(response => response.json())
        .then(data => {
            //console.log(data);
            location.href = 'offer.html?id=' + data;
        })
        .catch(error => console.error('An error occurred, price can not be calculated.', error));
}

function getOffer() {
    const params = new URLSearchParams(window.location.search);
    const offerContainer = document.getElementById('offerContainer');

    if (params.has('id')) {
        var offerIdentifier = params.get('id');
        console.log(offerIdentifier);
        fetch(`${offerUri}/${offerIdentifier}`)
            .then(response => response.json())
            .then(data => _displayOfferDetails(data))
            .catch(error => {
                console.error('An error occurred, could not fetch offer.', error);
                offerContainer.innerText = "Offert kan inte visas."
            });
    }
}

function showOfferForm() {
    const offerForm = document.getElementById('requestOfferForm');
    offerForm.style.display = 'block';
    offerForm.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
}

function _displayPrice(data) {
    const priceContainer = document.getElementById('price');
    priceContainer.innerText = `Uppskattat pris: ${data} kr inkl. moms`;
    priceContainer.style.display = 'block';
}

function _displayOfferDetails() {

}