/**
 * 1. todo ekleme
 * 2. tamamla butonu (complete)
 * 3. sil butonu olacak
 * 4. kayıt edilsin (localStorage, cookie) - sayfa yenilendiği zaman son hali yeniden görünsün
 *
 * --- optional
 * 1. güncelleme
 * 2. toplu silme
 * 3. eklenme - tamamlanma tarihi
 * 4. tamamlanma tarihi gelince alert version
 * 5. kategoriler koyulabilir -> spor, iş vs.
 */

const form= document.querySelector('form');
const input= document.querySelector('#txtTaskName');
const btnDeleteAll= document.querySelector('#btnDeleteAll');
const taskList= document.querySelector('#task-list');


eventListeners();

function eventListeners(){
    form.addEventListener('submit', addNewItem);
}


function addNewItem(e){
    if(input.value ===''){
        alert('Bir görev giriniz.');
    }

    // create li element
    const li=document.createElement('li');
    // add class
    li.className='list-group-item list-group-item-secondary';
    li.appendChild(document.createTextNode(input.value));

    // create a element
    const a=document.createElement('a');
    a.className='delete-item float-right';
    a.setAttribute('href','#');
    a.innerHTML='<i class="fas fa-times"></i>';

    // create text node and append to a
    li.appendChild(a);

    //add li to ul
    taskList.appendChild(li);
    
    //clear input
    input.value='';

    e.prenventDefault();

}