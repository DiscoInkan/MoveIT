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
            return data;
        })
        .catch(error => console.error('An error occurred, price can not be calculated.', error));
}


function createOffer() {
    const firstNameTextbox = document.getElementById('first-name');
    const lastNameTextbox = document.getElementById('last-name');
    const emailTextbox = document.getElementById('email');
    const fromAddressTextbox = document.getElementById('from-address');
    const toAddressTextbox = document.getElementById('to-address');
    const distanceTextbox = document.getElementById('distance');
    const livingSpaceTextbox = document.getElementById('living-space');
    const storageSpaceTextbox = document.getElementById('storage-space');
    const heavyItemCheckBox = document.getElementById('heavy-item');
    const priceData = document.getElementById('price');

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
                OfferPrice: priceData.dataset.price
            }
        ]
    };

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
            location.href = 'offer.html?id=' + data;
        })
        .catch(error => console.error('An error occurred, price can not be calculated.'));
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
                console.error('An error occurred, could not fetch offer.');
            });
    }
}

function showOfferForm() {
    const offerForm = document.getElementById('requestOfferForm');
    offerForm.style.display = 'block';
    offerForm.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
}

function _displayPrice(data) {
    if (data != null || data != 0) {
        const priceContainer = document.getElementById('price');
        const offerLink = document.getElementById('offerLink');

        priceContainer.innerText = `Uppskattat pris: ${data} kr inkl. moms`;
        priceContainer.setAttribute('data-price', data)
        priceContainer.style.display = 'block';
        offerLink.style.display = 'block';
        offerLink.scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
    }
    else {
        const priceContainer = document.getElementById('price');
        priceContainer.innerText = "pris kan ej visas.";
        priceContainer.style.display = 'block';
    }
}

function _displayOfferDetails(data) {
    const offerContainer = document.getElementById('offerContainer');
    const offerLink = document.getElementById('offerUniqueLink');

    const offerNumber = document.getElementById('offer-number');
    const offerName = document.getElementById('offer-name');
    const offerEmail = document.getElementById('offer-email');
    const offerFromAddress = document.getElementById('offer-fromaddress');
    const offerToAdddress = document.getElementById('offer-toaddress');
    const offerDistance = document.getElementById('offer-distance');
    const offerLivingSpace = document.getElementById('offer-livingspace');
    const offerStorageSpace = document.getElementById('offer-storagespace');
    const offerHeavyItem = document.getElementById('offer-heavyitem');

    const priceContainer = document.getElementById('price');
    

    offerLink.href = "https://localhost:7002/offer.html?id=" + data.offerIdentifier;
    offerLink.innerText = "https://localhost:7002/offer.html?id=" + data.offerIdentifier;
    offerNumber.innerText = "";
    offerName.innerText = "";
    offerEmail.innerText = "";
    offerFromAddress.innerText = data.fromAddress;
    offerToAdddress.innerText = data.toAddress;
    offerDistance.innerText = data.distance;
    offerLivingSpace.innerText = data.livingSpace;
    offerStorageSpace.innerText = data.storageSpace;
    offerHeavyItem.innerText = data.heavyItem;
    priceContainer.innerText = `Uppskattat pris: ${data.offerPrice} kr inkl. moms`;

    offerContainer.style.display = 'block';
    priceContainer.style.display = 'block';
}