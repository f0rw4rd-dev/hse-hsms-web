const addComponentModal = document.getElementById('add-component-modal')
const addButton = document.getElementById('add-button')
const addInputWarranty = document.getElementById('add-input-warranty');
const addInputComponentType = document.getElementById('add-input-componenttype');

async function fillComponentTypes(inputComponentType) {
    const componentTypes = await getComponentTypes();

    while (inputComponentType.firstChild) {
        inputComponentType.removeChild(inputComponentType.firstChild);
    }

    for (const componentType of componentTypes) {
        const option = document.createElement('option');
        option.value = componentType.id;
        option.textContent = componentType.name;

        inputComponentType.appendChild(option);
    }
}

async function addComponentForm() {

}

inputWarranty.addEventListener('keypress', validateInputOnlyNumbers);

document.addEventListener('DOMContentLoaded', async function (event) {
    await fillComponentTypes(addInputComponentType);
})

addComponentModal.addEventListener('show.bs.modal', function (event) {
    var button = event.relatedTarget

    var modalTitle = addComponentModal.querySelector('.modal-title')
    var modalBodyInput = addComponentModal.querySelector('.modal-body input')

    modalTitle.textContent = 'Добавить комплектующее'
})

addButton.addEventListener('click', function (event) {

})