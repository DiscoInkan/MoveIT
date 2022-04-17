const offerUri = 'api/offers';
const priceUri = 'api/price';

function calculatePrice() {
    const distanceTextbox = document.getElementById('distance');
    const livingSpaceTextbox = document.getElementById('living-space');
    const storageSpaceTextbox = document.getElementById('storage-space');
    const heavyItemCheckBox = document.getElementById('heavy-item');

    const model = {
        distance: distanceTextbox.value.trim(),
        livingSpace: livingSpaceTextbox.value.trim(),
        storageSpace: storageSpaceTextbox.value.trim(),
        hasHeavyItem: heavyItemCheckBox.value.trim()
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
            console.log(data);
        })
        .catch(error => console.error('An error occurred, price can not be calculated.', error));
}

function _displayPrice(data) {
    document.getElementById('price').innerText = `Uppskattat pris: ${data.document} inkl. moms`;
}