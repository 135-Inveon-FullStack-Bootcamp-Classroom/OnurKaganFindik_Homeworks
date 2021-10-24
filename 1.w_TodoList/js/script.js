/**
 * +1. todo ekleme
 * +2. tamamla butonu (complete)
 * +3. sil butonu olacak
 * +4. kayıt edilsin (localStorage, cookie) - sayfa yenilendiği zaman son hali yeniden görünsün
 *
 * --- optional
 * 1. güncelleme
 * +2. toplu silme
 * 3. eklenme - tamamlanma tarihi
 * 4. tamamlanma tarihi gelince alert version
 * 5. kategoriler koyulabilir -> spor, iş vs.
 */

const form= document.querySelector('form');
const input= document.querySelector('#txtTaskName');
const btnDeleteAll= document.querySelector('#btnDeleteAll');
const taskList= document.querySelector('#task-list');
const list = document.querySelector('ul');
let items;



// load items
loadItems();


//call event listeners
eventListeners();

function eventListeners(){
    //add task event
    form.addEventListener('submit', addNewItem);
    
    //delete Items event
    taskList.addEventListener('click', deleteItem);
    
    //delete all items
    btnDeleteAll.addEventListener('click', deleteAllItems);
    
    
    // Completed symbol when clicking on a list item
    list.addEventListener('click', thisCompleted , false);

}

//complate item
function thisCompleted(ev) {
    if (ev.target.tagName === 'LI') {
      ev.target.classList.toggle('checked');
    }
  }

 // load items 
function loadItems() {
    items = getItemsFromLS();
    items.forEach(function (item) {
        createItem(item);
    });
}

// get items from Local Storage
function getItemsFromLS(){
    if(localStorage.getItem('items')===null){
        items = [];
    }else{
        items = JSON.parse(localStorage.getItem('items'));
    }
    return items;
}

// set item to Local Storage
function setItemToLS(text){
    items = getItemsFromLS();
    items.push(text);
    localStorage.setItem('items',JSON.stringify(items));
}

// delete item from Local Storage
function deleteItemFromLS(text){
    items = getItemsFromLS();
    items.forEach(function(item,index){
        if(item === text){
            items.splice(index,1);   
        }
    });
    localStorage.setItem('items',JSON.stringify(items));
}

// create item
function createItem(text) {
    // create li
    const li = document.createElement('li');
    li.className = 'list-group-item list-group-item-secondary';
    li.appendChild(document.createTextNode(text));

    // create a
    const a = document.createElement('a');
    a.classList = 'delete-item float-right';
    a.setAttribute('href', '#');
    a.innerHTML = ' <i class="fas fa-times"></i>';

    // add a to li
    li.appendChild(a);

    // add li to ul
    taskList.appendChild(li);


}


//add new item
function addNewItem(e){
    if(input.value ===''){
        alert('Bir görev giriniz.');
    }

     // create item
     createItem(input.value);

     // save to LS
     setItemToLS(input.value);
 
     // clear input
     input.value = '';
 
     e.preventDefault();

}

//delete item
function deleteItem(e){
    if(e.target.parentElement.classList.contains('delete-item')){
        if(confirm('Görevi silinsin mi?')){
            e.target.parentElement.parentElement.remove();

            // delete item from Local Storage
            deleteItemFromLS(e.target.parentElement.parentElement.textContent);
        
        }
    }
    e.preventDefault();
        
}

//delete all items
function deleteAllItems(e){
    if(confirm('Tüm görevler silinsin mi?')){
        while(taskList.firstChild){
            taskList.removeChild(taskList.firstChild);
        }
        localStorage.clear();
    }
    e.preventDefault();
}
