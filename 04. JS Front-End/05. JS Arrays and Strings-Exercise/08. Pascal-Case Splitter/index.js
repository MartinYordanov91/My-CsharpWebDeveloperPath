function splitPascalCase(text){
    console.log(text.match(/[A-Z][a-z]*/g).join(", "))
}

splitPascalCase('SplitMeIfYouCanHaHaYouCantOrYouCan')