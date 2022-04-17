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

function showOfferForm() {
    document.getElementById('requestOfferForm').style.display = 'block';
}

function requestOffer() {

}

function _displayPrice(data) {
    const priceContainer = document.getElementById('price');
    priceContainer.innerText = `Uppskattat pris: ${data} kr inkl. moms`;
    priceContainer.style.display = 'block';
}