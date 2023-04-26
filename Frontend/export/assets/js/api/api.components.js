async function getComponents() {
    const response = await fetch("/api/Components", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        return await response.json();
    }
}

async function getComponent(id) {
    const response = await fetch(`/api/Components/${id}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        return await response.json();
    }
    else {
        const error = await response.json();
        console.log(error.message);
    }
}

async function putComponent(id, componentTypeId, name, warranty) {
    const response = await fetch(`/api/Components/${id}`, {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            id: id,
            componentTypeId: componentTypeId,
            name: name,
            warranty: warranty
        })
    });

    if (response.ok === false) {
        const error = await response.json();
        console.log(error.message);
    }

    return response.ok;
}

async function postComponent(componentTypeId, name, warranty) {
    const response = await fetch("api/Components", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            componentTypeId: componentTypeId,
            name: name,
            warranty: warranty
        })
    });

    if (response.ok === true) {
        return await response.json();
    }
    else {
        const error = await response.json();
        console.log(error.message);
    }
}

async function deleteComponent(id) {
    const response = await fetch(`/api/Components/${id}`, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === false) {
        const error = await response.json();
        console.log(error.message);
    }

    return response.ok;
}