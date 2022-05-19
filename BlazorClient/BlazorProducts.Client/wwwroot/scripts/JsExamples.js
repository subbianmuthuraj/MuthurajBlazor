export function showAlert(message) {
    alert(message);
}

export function showAlertObject(person) {
    const message = 'This person is called ' + person.name + ' and is ' + person.age + ' Years old';
    alert(message);
}

export function emailRegistraion(message) {
    const result = prompt(message);

    if (!email)
        return null;

    const firstpart = email.substring(0, email.indexOf("@"));
    const secondPart = email.substring(email.indexOf("@") + 1);

    return {
        'name': firstpart,
        'server': secondPart.split(".")[0],
        'domain': secondPart.split(".")[1]
    }
}

export function splitEmailDetails(message) {
    const email = prompt(message);

    if (!email)
        return null;

    const firstpart = email.substring(0, email.indexOf("@"));
    const secondPart = email.substring(email.indexOf("@") + 1);

    return {
        'name': firstpart,
        'server': secondPart.split(".")[0],
        'domain': secondPart.split(".")[1]
    }
}

export function focusAndStyleElement(element) {
    element.style.color = 'red';
    element.focus();
}