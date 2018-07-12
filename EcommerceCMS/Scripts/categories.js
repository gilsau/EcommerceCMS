$(document).ready(function () {

    //category source selected
    $('[name="CategorySource"]').change(function () {

        //hide dependencies
        $('#tdWebsites, #thWebTitle, #tdSuppliers, #thSuppTitle, #tblCategories').hide();

        //null dependency values
        $('[name="WebsiteId"]').val('0');
        $('[name="SupplierId"]').val('0');
    });

    //adjust breadcrumbs
    var linksCount = $('#H3BC').find('a').length;
    var newBC = '';
    $('#H3BC').find('a').each(function (idx, val) {
        console.log('val: ' + val.textContent);
        
        if (idx == (linksCount-1)) {
            val = val.textContent;
        }
        else {
            val = val.outerHTML;
        }

        newBC += (idx > 0 ? ' | ' + val : val);
    });
    $('#H3BC').html(newBC);
    BindGetProducts();
    BindGetProducts2();
    BindGetSubCats();
    BindGetTopCats();

    $('#selProdChk').click(function () {
        var isChecked = $('.prodChk').prop('checked');
        $('.prodChk').prop('checked', (isChecked ? false : true));
    });
});

function BindGetTopCats() {
    $('.spanGetTopCats').click(function () {
        $('[name="BreadCrumbs"]').val(ObfuscateHtml('<a href="#" data-level="1" data-id="0" data-name="TOP CATEGORIES" class="spanGetTopCats">TOP CATEGORIES</a>'));
        $('#frmMain').submit();
    });

}

function BindGetProducts2() {
    $('.spanMngProds2').on('click', function () {
        var btn = $(this);
        var parcatId = btn.attr('data-parid');
        var parcatName = btn.attr('data-parname');
        var parlinkLevel = btn.attr('data-parlevel');
        var catId = btn.attr('data-id');
        var catName = btn.attr('data-name');
        var linkLevel = btn.attr('data-level');

        SaveBreadCrumb(parcatId, parcatName, parlinkLevel);
        SaveBreadCrumb(catId, catName, linkLevel);

        $('[name="ParentCategoryId"]').val(btn.attr('data-id'));
        $('[name="ParentCategoryName"]').val(btn.attr('data-name'));
        $('[name="CategoryId"]').val(btn.attr('data-id'));
        $('#frmMain').submit();
    });
}

function BindGetProducts() {
    $('.spanMngProds').on('click', function () {
        var btn = $(this);
        var catId = btn.attr('data-id');
        var catName = btn.attr('data-name');
        var linkLevel = btn.attr('data-level');

        SaveBreadCrumb(catId, catName, linkLevel);

        $('[name="ParentCategoryId"]').val(btn.attr('data-id'));
        $('[name="ParentCategoryName"]').val(btn.attr('data-name'));
        $('[name="CategoryId"]').val(btn.attr('data-id'));
        $('#frmMain').submit();
    });
}

function BindGetSubCats() {
    $('.spanMngSubCats').on('click', function () {
        var btn = $(this);
        var catId = btn.attr('data-id');
        var catName = btn.attr('data-name');
        var linkLevel = btn.attr('data-level');

        SaveBreadCrumb(catId, catName, linkLevel);

        $('[name="ParentCategoryId"]').val(btn.attr('data-id'));
        $('[name="ParentCategoryName"]').val(btn.attr('data-name'));
        $('#frmMain').submit();
    });
}

function SaveBreadCrumb(catId, catName, linkLevel) {
    var bc = $('[name="BreadCrumbs"]').val();
    var arrLinks = bc.indexOf('|') > -1 ? bc.split('|') : [bc];
    var htmlToAdd = ObfuscateHtml('<a href="#" class="spanMngSubCats" data-level="' + linkLevel + '" data-id="' + catId + '" data-name="' + catName + '">' + catName + '</a>');
    var bc2 = "";

    //add to array of links
    arrLinks[linkLevel-1] = htmlToAdd;

    //concatenate links
    for (var i = 0; i < linkLevel; i++) {
        bc2 += (i == 0 ? arrLinks[i] : (' | ' + arrLinks[i]));
    }

    //save breadcrumbs in hidden form var
    $('[name="BreadCrumbs"]').val(bc2);
}

function ObfuscateHtml(str) {
    return str.replace(/</gi, '&lt;').replace(/>/gi, '&gt;');
}