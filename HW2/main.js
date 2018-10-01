function addNewCard(){
    var word = document.getElementById('word').value;
    var define = document.getElementById('defin').value;
    
    
    
    if(word.length == 0){
        alert("Can't submit a blank card");
        return;
    }
    else if (define.length == 0){
        alert("You must submit a definition for your word");
        return;
    }
    else
        /*Make a flash card*/
        $('col-md-6').append("<div class='card'><div class ='front'><span>"+word+"</span></div></div>")
        $('col-md-6').append("<div class='card'><div class ='back'><span>"+define+"</span></div></div>")

}


function main(){
    
    $('.submit-btn').on('click', function(){ addNewCard(); $('#add')[0].reset();})
                        
    
}

$(document).ready(main);