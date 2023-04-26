async function getComponentTypes() {
    const response = await fetch("/api/ComponentTypes", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        return await response.json();
    }
}

async function getComponentType(id) {
    const response = await fetch(`/api/ComponentTypes/${id}`, {
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

async function putComponentType(id, name) {
    const response = await fetch(`/api/ComponentTypes/${id}`, {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            id: id,
            name: name
        })
    });

    if (response.ok === false) {
        const error = await response.json();
        console.log(error.message);
    }

    return response.ok;
}

async function postComponentType(name) {
    const response = await fetch("api/ComponentTypes", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            name: name
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

async function deleteComponentType(id) {
    const response = await fetch(`/api/ComponentTypes/${id}`, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === false) {
        const error = await response.json();
        console.log(error.message);
    }

    return response.ok;
}