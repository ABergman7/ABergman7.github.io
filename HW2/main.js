function main(){
    
    $('.submit-btn').on('click', addNewCard());
                        
    
}


function addNewCard() {
    
    console.log("addNewCard");
    var word = document.getElementById('wordInput').value;
    var define = document.getElementById('defInput').value;
    
    
    
    /*if(word.length == 0 ){
        alert("Can't submit a blank card");
        return;
    }
    else if (define.length == 0){
        alert("You must submit a definition for your word");
        return;
    }
    else
    */
        /*Make a flash card*/
        $('.card-inner').append("<div class ='card-front'><span>"+word+"</span></div></div>")
        $('.card-inner').append("<div class ='card-back'><span>"+define+"</span></div></div>")

}

$(document).ready(main);