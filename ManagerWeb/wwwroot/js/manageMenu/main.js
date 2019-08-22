var menuData;
// selectedOptionIndex
// -1 : new option mode
//  0 : all option mode
// 1+ : normal option mode
var selectedOptionIndex;
init();

function init(){
    GetShopMenu(ResopnseData,function(data){
        menuData = data;
        changeOption(0);
        initShopName();
        initOptionButton();
    });
}

function InitItemTable(items,addItemButtonClick){    
    var addItemButton = document.getElementById('addItemButton');
    if (addItemButtonClick===undefined){
        addItemButton.onclick="newItemButtonClick()";
    }else{
        addItemButton.onclick=addItemButtonClick;
    }

    var itemTable = document.getElementById('itemTable');
    
    // clear 
    for (;2< itemTable.childNodes.length;){
        itemTable.removeChild(itemTable.lastChild);
    }

    if (!items){
        return;
    }
    items.forEach(function(item) {
        var newTr = NewItemTableTr(item,null);
        itemTable.appendChild(newTr);
    }); 
}

function InitCurrentOptionName(name){
    var currentOptionNameA = document.getElementById('currentOptionNameA');
    var itemOptionNameTd = document.getElementById('newItemOptionNameTd');
    
    var itemOptionName = name;
    if (name === undefined){
        menuOption = menuData.Options[selectedOptionIndex];
        name = menuOption.Name;

        if (menuOption.Option){
            itemOptionName = name;
        }else{
            itemOptionName = "";
        }
    }

    currentOptionNameA.innerHTML = name;
    itemOptionNameTd.innerHTML = itemOptionName;
}

function InitSelectionTable(selectedOptionIndex,selections, newSelectionButtonClick){
    var selectionTableTd = document.getElementById('selectionTableTd');
    // clear 
    selectionTableTd.innerHTML = "";

    if (selectedOptionIndex === 0){
        return ;
    }

    // init
    var a = document.createElement('a');
    a.innerHTML = "選單選項";
    selectionTableTd.appendChild(a);
    var selectionTable = document.createElement('table');
    selectionTable.id = "selectionTable"
    selectionTableTd.appendChild(selectionTable);

    // first row
    var newTr = document.createElement('tr');
    selectionTable.appendChild(newTr);
    
    var newTd = document.createElement('td');
    newTd.innerHTML = "名稱";
    newTr.appendChild(newTd);

    newTd = document.createElement('td');
    newTd.innerHTML = "加價";
    newTr.appendChild(newTd);

    newTd = document.createElement('td');
    newTd.innerHTML = "操作";
    newTr.appendChild(newTd);

    // second row
    newTr = document.createElement('tr');
    selectionTable.appendChild(newTr);
    
    newTd = document.createElement('td');
    var newInput = document.createElement('input');
    newInput.id = "newSelectionNameInput";
    newTd.appendChild(newInput);
    newTr.appendChild(newTd);

    newTd = document.createElement('td');
    newInput = document.createElement('input');
    newInput.id = "newSelectionPriceInput";
    newTd.appendChild(newInput);
    newTr.appendChild(newTd);

    newTd = document.createElement('td');
    var newButton = document.createElement('button');
    newButton.id = "addSelectionButton";
    newButton.innerHTML="新增";
    if (newSelectionButtonClick === undefined){
        newButton.onclick =this.newSelectionButtonClick;    
    }else{
        newButton.onclick =newSelectionButtonClick;
    }
    newTd.appendChild(newButton);
    newTr.appendChild(newTd);


    if (!selections){
        return;
    }
    selections.forEach(function(selection) {
        selection.Price = (selection.Price)? selection.Price : 0;
        var newTr =NewSelectionTableTr(selection)
        selectionTable.appendChild(newTr);
        }); 
}

function initOptionNumSelect(){
    // clear
    var optionSelectTd = document.getElementById('optionSelectTd');
    optionSelectTd.innerHTML = "";
            
    menuOption = menuData.Options[selectedOptionIndex];
    menuSelections = menuOption.Selections;
    if (!menuSelections){
        return ;
    }
    
    var select = CreateOptionNumSelect();
    for (let i = 1; i <= menuSelections.length; i++){
        let option = document.createElement('option');
        option.value = i;
        option.innerHTML = i;
        select.options.add(option);
    }    
}

function initShopName(){
    document.getElementById('shopNameInput').value = menuData.Shop.Name;   
}

function initOptionButton(){
    var optionTable = document.getElementById('optionTable');
    optionTable.innerHTML=""
    
    var optionButtonTr = document.createElement('tr');
    optionTable.appendChild(optionButtonTr)    

    var optionRmButtonTr = document.createElement('tr');
    optionTable.appendChild(optionRmButtonTr);
        
    for (let index = 0;menuData.Options && index < menuData.Options.length;index++){
        let menuOption = menuData.Options[index];

        var newOptionButtonTd = document.createElement('td');
        optionButtonTr.appendChild(newOptionButtonTd);

        var newRmButtonTd = document.createElement('td');
        optionRmButtonTr.appendChild(newRmButtonTd);
        
        // add button
        var newButton = document.createElement('button');
        newOptionButtonTd.appendChild(newButton);

        var id= 'none';
        if (menuOption.Option){            
            // add remove option button to td
            var newRmButton = document.createElement('button');
            newRmButton.innerHTML = "-";
            newRmButton.addEventListener('click',function(){
                removeOptionButtonClick(index);
            });
            newRmButtonTd.appendChild(newRmButton)

            id = index;
        }
        newButton.Name = id + "OptionButton";
        newButton.innerHTML = menuOption.Name;
        newButton.addEventListener('click',function(){
            changeOption(index);
        });
    }
    
    // add option button
    var addOptionTd = document.createElement('td');
    optionButtonTr.appendChild(addOptionTd);
    var addOptionButton = document.createElement('button');
    addOptionButton.id = "addOptionButton";
    addOptionButton.innerHTML = "+";
    addOptionButton.onclick =newOptionButtonClick;
    addOptionTd.appendChild(addOptionButton);

    var tdForAddOption = document.createElement('td');
    optionRmButtonTr.appendChild(tdForAddOption);
}

function CreateOptionNumSelect(){
    var optionSelectTd = document.getElementById('optionSelectTd');
    var a = document.createElement('a');
    a.innerHTML = "必選數量";
    optionSelectTd.appendChild(a);


    var select = document.createElement('select');
    select.innerHTML = "必選數量";
    select.id = "selectNumSelect"
    optionSelectTd.appendChild(select);

    var option = document.createElement('option');
    option.value = 0;
    option.innerHTML = "0";
    select.options.add(option);    

    return select;
}

function changeOption(index){
    selectedOptionIndex = index
    InitCurrentOptionName();
    initOptionNumSelect();
    menuOption = menuData.Options[selectedOptionIndex]
    InitItemTable(menuOption.Items);
    InitSelectionTable(selectedOptionIndex, menuOption.Selections);
}

// button click

function newItemButtonClick(){
    var itemNameInput = document.getElementById('newItemNameInput');
    var name = itemNameInput.value;
    if (!name){
        alert("please input name!");
        return ;
    }

    var itemPriceInput = document.getElementById('newItemPriceInput');
    var price =parseInt(itemPriceInput.value);
    if (isNaN(price)){
        alert("please input integer price");
        return;
    }


    AddItem(menuData.Shop.ID,name,price,function(data){
        init();
    });
}

function newSelectionButtonClick(){
    var selectionNameInput = document.getElementById('newSelectionNameInput');
    var name = selectionNameInput.value;
    if (!name){
        alert("please input name!");
        return ;
    }

    var selectionPriceInput = document.getElementById('newSelectionPriceInput');
    var price =parseInt(selectionPriceInput.value);
    if (isNaN(price)){
        alert("please input integer price");
        return;
    }

    AddSelection(menuData.Shop.ID,name,price,function(data){
        init();
    });
}

function newOptionButtonClick(){
    var url = 'manager/newoption';
    $.ajax({
            type:'GET',
            url: url
        }).done(UpdatePage);
}

function removeShopButtonClick(){
    shopID = menuData.Shop.ID;        
    if (!shopID){
        alert("delete err");
        return 
    }

    DeleteShop(
        shopID,// from tree node js
        function(success){
            if (!success){
                alert('fail');
                return ;
            }

            var url = '/manager/menutree';
            $.ajax({
                type:'GET',
                url: url
            }).done(UpdatePage);

            toNewShop();
            
            alert('刪除商店成功!');
        }	
    );
}

function removeOptionButtonClick(index){
    var menuOption = menuData.Options[index]
    var optionID = menuOption.Option.ID
    DeleteOption(optionID,function(data){
        if (data){
            alert("Delete Option Success")
            init()
        }        
    })
}

function shopNameInputKeyPress(shopName){
    if (window.event.keyCode==13){
        shopID = menuData.Shop.ID;        
        if (!shopID){
            alert("delete err");
            return false;
        }      

        oldShopName = menuData.Shop.Name;     
        if (!shopName){
            alert("err")
            return false;
        }else if (shopName == ""){
            alert("please input shop name!")
            return false;
        }else if (shopName == oldShopName){
            return false
        }

        UpdateShop(shopID,shopName,
            function(success){
                if (!success){
                    alert('fail');
                    return ;
                }
    
                var url = '/manager/menutree';
                $.ajax({
                    type:'GET',
                    url: url
                }).done(UpdatePage);
    
                alert('修改商店成功!');
            }
        )

        return false;
    };
}

function NewItemTableTr(item, deleteButtonClick){
    var newTr = document.createElement('tr');

    var newTd = document.createElement('td');
    newTd.innerHTML = item.Options;
    newTr.appendChild(newTd);

    newTd = document.createElement('td');
    newTd.innerHTML = item.Name;
    newTr.appendChild(newTd);

    newTd = document.createElement('td');
    newTd.innerHTML = item.Price;
    newTr.appendChild(newTd);

    newTd = document.createElement('td');
    var newButton = document.createElement('button');
    newButton.innerHTML ="刪除";
    newButton.onclick = deleteButtonClick;
    newTr.appendChild(newButton);

    return newTr;
}

function NewSelectionTableTr(selection, deleteButtonClick){
    var newTr = document.createElement('tr');

    var newTd = document.createElement('td');
    newTd.innerHTML = selection.Name;
    newTr.appendChild(newTd);

    newTd = document.createElement('td');
    var price = (selection.Price)? selection.Price : 0;
    newTd.innerHTML = price;
    newTr.appendChild(newTd);

    var newButton = document.createElement('button');
    newButton.innerHTML ="刪除";
    if (deleteButtonClick === undefined){
        newButton.onclick = this.deleteButtonClick;    
    }else{
        newButton.onclick = deleteButtonClick;
    }
    newTr.appendChild(newButton);

    return newTr;
}