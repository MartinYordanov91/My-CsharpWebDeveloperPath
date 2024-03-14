function objToJson(name, lastName, hairColor) {
    const obj = {
        name,
        lastName,
        hairColor
    }

    console.log(JSON.stringify(obj))
}

objToJson('George', 'Jones', 'Brown')
objToJson('Peter', 'Smith', 'Blond')