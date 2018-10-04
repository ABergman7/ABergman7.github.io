
function addNewCard() {
  
    var word = document.getElementById('wordInput').value;
    var define = document.getElementById('defInput').value;
    
    if(word.length == 0 ){
        alert("Can't submit a blank card");
        return;
    }
    else if (define.length == 0){
        alert("You must submit a definition for your word");
        return;
    }
    else {

        /*Make a flash card*/
        $('.card-inner').append("<div class='card-front'><h1>"+word+"</h1></div><div class='card-back'><h2>"+define+"</h2></div></div>");
        $('.deck').append("<dl><dt class ='dtTitle'>"+word+"</dt></dl>");
        
        
    
        
        
        
        
        
    }
    
    
    console.log(word);
    
    
}
