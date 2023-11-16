<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="AdsSprit.AdsSpritAdmin.Footer" %>
<footer class="ft_fix">
    <p class="pull-left" style="color:#fff; padding:5px 0 0 0;margin-left: 40px;">© Copyright 2023</p>
    <p class="pull-right" style="text-align:right; color:#fff; padding:5px 40px 0 0;">Powered by : <a href="http://ibrandox.com/" target="_blank"><img src="/AdsSpritAdmin/images/ox.png" width="71" height="18" alt="iBrandox Online Pvt Ltd" title="Ibrandox Online Pvt Ltd" /></a></p>
</footer>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script>
    $(document).ready(function () {

        chekWherePhotoCake();
        //        if ($('#DDPhoteCake').val() === "Yes") {
        //            $('.HdOn').show();
        //            alert("Hi");
        //        }
        //        else {
        //            $('.HdOn').hide();
        //            alert("Hii");
        //        }
        var pathname = window.location.pathname;

        var pathname1 = window.location.pathname;

        $('.Header_nav_Active > ul > li > a[href="' + pathname + '"]').addClass('hdractive');


        $('.Header_nav_Active > ul > li > ul > li > a[href="' + pathname1 + '"]').addClass('hdractiveSAub');

        if (pathname1 === "/AdsSpritAdmin/addupd-delivery-time") {
            pathname1 = "/AdsSpritAdmin/delivery-time"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-location") {
            pathname1 = "/AdsSpritAdmin/location"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-disable-time-slot") {
            pathname1 = "/AdsSpritAdmin/disable-time-slot"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-category") {
            pathname1 = "/AdsSpritAdmin/category"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-sub-category") {
            pathname1 = "/AdsSpritAdmin/sub-category"
        }
        else if (pathname1 === "/AdsSpritAdmin/add-flavour") {
            pathname1 = "/AdsSpritAdmin/flavour"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-package") {
            pathname1 = "/AdsSpritAdmin/package"
        }
        else if (pathname1 === "/AdsSpritAdmin/add-design") {
            pathname1 = "/AdsSpritAdmin/design"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-occasion") {
            pathname1 = "/AdsSpritAdmin/occasion"
        }
        else if (pathname1 === "/AdsSpritAdmin/add-add-ons") {
            pathname1 = "/AdsSpritAdmin/add-ons"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-product-data") {
            pathname1 = "/AdsSpritAdmin/product-data"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-coupan") {
            pathname1 = "/AdsSpritAdmin/coupan"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupdate-comment") {
            pathname1 = "/AdsSpritAdmin/comments"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-customer") {
            pathname1 = "/AdsSpritAdmin/cutomer"
        }
        else if (pathname1 === "/AdsSpritAdmin/view-order-history") {
            pathname1 = "/AdsSpritAdmin/order"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-testinomials") {
            pathname1 = "/AdsSpritAdmin/testinomials"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-blog-data") {
            pathname1 = "/AdsSpritAdmin/blog-data"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-blog-data") {
            pathname1 = "/AdsSpritAdmin/blog-data"
        }
        else if (pathname1 === "/AdsSpritAdmin/addupd-store-locator") {
            pathname1 = "/AdsSpritAdmin/Manage-store-locator"
        }
        else {
            var pathname1 = window.location.pathname;
        }
        pathname = pathname1;
        $('.Header_nav_Active > ul > li > a[href="' + pathname + '"]').addClass('hdractive');
        $('.Header_nav_Active > ul > li > ul > li > a[href="' + pathname1 + '"]').addClass('hdractiveSAub');
        $('.hdractiveSAub').each(function () {
            $(this).parents('.nav-second-level').addClass('in hgauto');
        });
    });

    function chekWherePhotoCake() {
        if ($('#DDPhoteCake').val() === "Yes") {
            $('.HdOn').show();
        }
        else {
            $('.HdOn').hide();
        }
    }
</script>
<script language="javascript">
    $(function () {
        $(".datepicker").datepicker({
            showOn: "button",
            buttonImage: "http://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
            buttonImageOnly: true,
            buttonText: "Select date"
        });
    });

    $('.chart__bar').children().addClass('chart__act');
    $(".chart__bar > span[rerd-height]").each(function () {
        $(this).css({
            height: $(this).attr('rerd-height')
        });
    });
    $(document).ready(function () {
        Bind();
    });
    function Bind() {
        var ar2 = new Array();
        $(".chart__bar").each(function () {
            ar2.push(parseInt($(this).attr('data-att')));
        });
        ar2.sort((a, b) => {
            if (a < b) {
                return -1;
    }
    if (a > b) {
        return 1;
    }
    return 0;
    });
    for ( var i = 0, l = ar2.length; i < l; i++ ) {
        $(".chart__bar").each(function () {
            if($(this).attr('data-att') == ar2[ i ]){
                $(this).attr('data-value',(i + 1))
            }
        });
    }
    }
  </script>
<script src="/AdsSpritAdmin/js/jquery-1.10.2.js"></script> 
<script src="/AdsSpritAdmin/js/bootstrap.min.js"></script> 
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.js"></script>
<script src="/AdsSpritAdmin/Js/jquery-ui.js" type="text/javascript"></script>
<script src="/AdsSpritAdmin/js/jquery.metisMenu.js"></script> 
<script src="/AdsSpritAdmin/js/raphael-2.1.0.min.js"></script> 
<script src="/AdsSpritAdmin/js/morris.js"></script>
<script src="/AdsSpritAdmin/js/custom-scripts.js"></script>
<script type="text/javascript">

    $('.trg_back').click(function () {
        $('.nav-tabs li.active').prev().children('a').trigger('click');
    });
    $('.trg_next').click(function () {
        $('.nav-tabs li.active').next().children('a').trigger('click');
    });

    $('.timepicker').timepicker({

        scrollbar: true
    });
</script>
<script>
    $('.from_date').datepicker({ minDate: 'D', dateFormat: 'mm/dd/yy', prevText: '<i class="fa fa-chevron-left"></i>',
        nextText: '<i class="fa fa-chevron-right"></i>',
        onClose: function (selectedDate) {
            $(".to_date").datepicker("option", "minDate", selectedDate);
            $(this).parents('fieldset').next().children().focus();
        }
    });
</script>