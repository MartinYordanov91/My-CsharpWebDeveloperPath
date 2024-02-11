function censoring(text, word){
    console.log(text.replace(new RegExp(word,"g"), "*".repeat(word.length)))
}

censoring('A small sentence with some words', 'small')
censoring('Find the hidden word', 'hidden')