(function() {
    "use strict";
    var winH = "",
        winW = "",
        hdrH = "",
        topHdr = "",
        ftrH = "",
        st = "";
    winH = $(window).height();



    // Change text value of headEnq-btn on mobile screen
    function headEnq() {
        if (winW <= 767) {
            // $('.headEnq-btn').text('Enquiry');

        } else {
            // $('.headEnq-btn').text('Enquiry For Lease');

        }
    }

    $(window).resize(function() {
        winH = $(window).height();
        winW = $(window).width();
        hdrH = $('header').innerHeight();
        ftrH = $('footer').innerHeight();
        topHdr = $('.PTM-Txt-Bx').innerHeight()
        $('main').css({ 'margin-top': topHdr })
        console.log(hdrH)

        // Call headEnq() function 
        headEnq()
    });
    $(window).load(function() {
        $(window).trigger('resize');
        setTimeout(function() { $('.GrnbSecmn').addClass('PrlDelPgern'); }, 500);
    });



    $(window).scroll(function() {
        st = $(this).scrollTop();
        if (st > winH) {

        } else {

        }
    });




    $(document).ready(function() {
        $(window).scroll(function() {
            if (($(window).scrollTop()) > ($(window).height()) / 100) {
                $('header').addClass('hdrDown');
            } else {
                $('header').removeClass('hdrDown');
                $('.flsprcmd').removeClass('fxdSemn');
            }
        });

        var ImgAtrvr = $('.PrpndImgSwnvr').attr('src');

        $('.ApndMnsvr').attr('src',ImgAtrvr);

        if ($(window).width() > 767) {
             


             }
            else { 
               $('.ArwnSwn').click(function () {
                   $('.MegaMenu').slideToggle('slow');
               })

                $('.ArwnSwnSec').click(function () {
                    $(this).parents('.MegaMenu__Item').siblings().find('.Linklist').slideUp('slow');
                    $(this).parents('.MegaMenu__Item').find('.Linklist').slideToggle('slow');
                });

                $('.clsbtnVr').click(function (){
                    $('.cl6mnSwnright').slideUp('slow').removeClass('menu-actice');;
                });

                $('.nvrSwbnVr').click(function () {
                    $('.cl6mnSwnright').slideDown('slow').addClass('menu-actice');
                })
            }


        $(".DrpDwn").hover(function() {
                $('header').addClass('hdrDownnvr');
                $('.cl12SemnvrtNavImg').addClass('hdrtrnvt');
            },
            function() {
                $('header').removeClass('hdrDownnvr');
                $('.cl12SemnvrtNavImg').addClass('hdrtrnvt');
            });

        $('.UntOwn').click(function () {
            $('.tieSemn').slideUp('show');
            $('.OwnUntVr').slideDown('slow');
        });

        $('.tieUp').click(function () {
            $('.tieSemn').slideDown('show');
            $('.OwnUntVr').slideUp('slow');
        });


        $('.SrcoSldrCn').owlCarousel({
            items: 1,
            loop: true,
            margin: 0,
            dots: true,
            nav: false,
            autoplayTimeout: 8000,
            autoplayHoverPause: false,
            smartSpeed: 8000,
            slideSpeed: 8000,
            animateIn: 'fadeInDown',
            autoplay: true,
            nav: false,
            responsive: {
                0: {
                    items: 1,
                    margin: 0
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        });

        $('.SrcoSldrCnDlpge').owlCarousel({
            items: 1,
            loop: true,
            margin: 0,
            dots: true,
            nav: false,
            autoplayTimeout: 4000,
            autoplayHoverPause: false,
            smartSpeed: 4000,
            slideSpeed: 4000,
            animateIn: 'fadeInDown',
            autoplay: true,
            nav: false,
            responsive: {
                0: {
                    items: 1,
                    margin: 0
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        });

        $('.awrdSldrMn').owlCarousel({
            items: 1,
            loop: true,
            margin: 0,
            dots: false,
            autoplayTimeout: 4000,
            autoplayHoverPause: false,
            smartSpeed: 4000,
            slideSpeed: 4000,
            autoplay: false,
            nav: true,
            navText: ["<div class='lftCr'></div>", "<div class='rgtCr'></div>"],
            responsive: {
                0: {
                    items: 1,
                    margin: 0
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        });

        $('.RldtdProSecmn').owlCarousel({
            items: 3,
            loop: true,
            margin: 25,
            dots: false,
            autoplayTimeout: 4000,
            autoplayHoverPause: false,
            smartSpeed: 4000,
            slideSpeed: 4000,
            autoplay: false,
            nav: true,
            navText: ["<div class='lftCr'></div>", "<div class='rgtCr'></div>"],
            responsive: {
                0: {
                    items: 1,
                    margin: 0
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 3
                }
            }
        });


        $('.MreMediSeSwn').owlCarousel({
            items: 3,
            loop: true,
            margin: 35,
            dots: false,
            autoplayTimeout: 4000,
            autoplayHoverPause: false,
            smartSpeed: 4000,
            slideSpeed: 4000,
            autoplay: false,
            nav: true,
            navText: ["<div class='lftCr'></div>", "<div class='rgtCr'></div>"],
            responsive: {
                0: {
                    items: 1,
                    margin: 0
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 3
                }
            }
        });

        $('.LndHeadr').each(function() {
            var myBGImg = $(this).children('img.bg').attr('src');
            $(this).children('img.bg').hide();
            $(this).css({
                'background': 'url(' + myBGImg + ') center top',
                'background-size': 'cover',
                'background-attachment': 'fixed'
            });
        });

        (function() {
            $('.formcntl,.FtrInpt,.frm-cntrl').focusout(function() {
                if ($(this).val() != "") {
                    $(this).siblings('.frmlbel,.InptTxtName,.label-wrp,.label-wrap').addClass('hasVal')
                } else {
                    $(this).siblings('.frmlbel,.InptTxtName,.label-wrp,.label-wrap').removeClass('hasVal')
                }
            });
        })();

        $('.fileInpt_ImgH ').change(function(eq) {
            var FilPath = eq.target.files[0].name;
            $('.fileLbl_ImgH small').text(FilPath)
        });

        $('.CreNameSec').click(function() {
            // $('.DrpDownSec').removeClass('MinusAdd')  
            $(this).parents('.OppSecRpt').siblings().find('.CntSecDrpDown').slideUp('slow');
            $(this).parents('.OppSecRpt').siblings().find('.DrpDownSec').removeClass('MinusAdd');
            $(this).parents('.OppSecRpt').find('.CntSecDrpDown').slideToggle('slow');
            $(this).find('.DrpDownSec').toggleClass('MinusAdd');
        });

           $('body').click(function (e) {
              var catFilterCont = $(".TeamPop-Wppr,.Clm-xl-4");
              if (!catFilterCont.is(e.target) && catFilterCont.has(e.target).length === 0) {
                      $('.TeamImg-Wppr').children('span').find('img').attr('src', '');
                        $('.TeamName').text();
                        $('.TeamPrfl').text();
                        $('.TemContct-Wppr').slideUp('slow');
              }
          });

        $(window).scroll(function() {
            $('.AnimateSec').each(function() {
                if ($(window).scrollTop() >= $(this).offset().top - window.innerHeight / 4.5) {
                    $(this).addClass('activeAnimte');
                } else {
                    $(this).removeClass('activeAnimte');
                }
            });
        });

        // End Here
        // Product Page js

        $(".VideObtnSec").click(function() {
            $(".pop_up_vdo1").addClass("pop_up_vdo_opn1");
            $(".pop_up_vdo1").show();
            $(".vdo_onply1").addClass("vdo_onply_ad1");
            var Vdefrm = $(this).attr("data-atrshw");
            $(".TstIfrmeSec").attr("src", Vdefrm);
            $(".TstIfrmeSec").attr("src", $(".TstIfrmeSec").attr("src").replace("autoplay=0", "autoplay=1"));
        });

        $(".ClseIfrmSec").click(function() {
            $(".pop_up_vdo1").hide();
            $(".TstIfrmeSec").attr("src", $(".TstIfrmeSec").attr("src").replace("autoplay=1", "autoplay=0"));
        });
        // End Here
        // Product Details Page js 

        $('.RdMrBtn').click(function() {
            if ($(this).text() == 'Read less') {
                $(this).text('Read More');
                $(this).append("<img class='arwmove' src='asset/icon/icnlnvr.png'>")
                $('.PeraHgt').removeClass('AutoHgt');
            } else {
                $(this).text('Read less');
                $(this).append("<img class='arwmove' src='asset/icon/icnlnvr.png'>")
                $('.PeraHgt').addClass('AutoHgt');
            }
        });

        $('.RylSlr-Wppr').owlCarousel({
            items: 1,
            loop: true,
            margin: 0,
            dots: true,
            nav: false,
            autoplayTimeout: 4000,
            autoplayHoverPause: false,
            smartSpeed: 4000,
            slideSpeed: 4000,
            autoplay: true,
        });
        // End Here 
        // Aboutus page js 

        
        $('.JrnySldr').owlCarousel({
            items: 1,
            loop: true,
            margin: 35,
            dots: true,
            autoplayTimeout: 4000,
            autoplayHoverPause: false,
            smartSpeed: 4000,
            slideSpeed: 4000,
            autoplay: false,
            nav: false,
            navText: ["<div class='lftCr'></div>", "<div class='rgtCr'></div>"],
            responsive: {
                0: {
                    items: 1,
                    margin: 0
                },
                600: {
                    items: 1,
                    
                },
                1000: {
                    items: 1,
                  
                }
            }
        });


        $('.VluSlr-Bx').owlCarousel({
            items: 3,
            loop: true,
            margin: 50,
            dots: false,
            autoplayTimeout: 4000,
            autoplayHoverPause: false,
            smartSpeed: 4000,
            slideSpeed: 4000,
            autoplay: false,
            nav: true,
            navText: ["<div class='lftCr'></div>", "<div class='rgtCr'></div>"],
            responsive: {
                0: {
                    items: 1,
                    margin: 0
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 3
                }
            }
        });


        $('.LdrTbngBtn-Itm .title ul li').click(function() {
            var $thisAttr = $(this).attr('data-tbid');
            $('.LdrTbngBtn-Itm .title ul li').removeClass('Actv');
            $(this).addClass('Actv');
            $('.LdrTbCont-Itm').each(function() {
                if ($(this).attr('data-tbcntc') == $thisAttr) {
                    if ($(this).hasClass('Curnt')) {

                    } else {
                        setTimeout(function() { $('.LdrTbCont-Itm').removeClass('Curnt') }, 2000);
                        $('.LdrTbCont-Itm').hide('slow')
                        $(this).show('slow')

                    }
                }
            });

        });

        var Count = 1;
        var ContctCont = 1;

        //this is check code


        //$(document).ready(function () {
        //    $('.LdrTbngBtn-Itm li').click(function () {
        //        var $ThisId = $(this).data('tbid'); // Use data-tbid

        //         Hide all leader details
        //        $('.LdrTbCont-Itm').hide();

        //         Show the leader details for the clicked leader
        //        $('.LdrTbCont-Itm[data-tbcntc="' + $ThisId + '"]').show(); // Use data-tbcntc
        //    });
        //});  

        //test







        $('.TeamCont-Wppr').children('.Clm-xl-4').each(function() {
            $(this).attr('data-temid', Count);
            Count++
        });

        $('.TemTxtItm-Wppr').each(function() {
            $(this).attr('data-temtxtid', ContctCont);
            ContctCont++
        });


        $('.Clm-xl-4').click(function() {
            var $ThisId = $(this).attr('data-temid');
            var ImgSrc = $(this).children('.Tem-Img').find('img').attr('src');
            var Name = $(this).children('.title').find('small').text();
            var Prfl = $(this).children('.title').find('em').text();
            $('.TeamImg-Wppr').children('span').find('img').attr('src', ImgSrc);
            $('.TeamName').text(Name);
            $('.TeamPrfl').text(Prfl);
            $('.TemContct-Wppr').slideDown('slow');
            $('.TemTxtItm-Wppr').each(function() {
                if ($(this).attr('data-temtxtid') == $ThisId) {
                    if ($(this).hasClass('CrntData')) {

                    } else {
                        $('.TemTxtItm-Wppr').removeClass('CrntData')
                        $(this).addClass('CrntData')
                    }
                }
            });
        });

        $('.ClsPopBtn').click(function() {
            $('.TeamImg-Wppr').children('span').find('img').attr('src', '');
            $('.TeamName').text();
            $('.TeamPrfl').text();
            $('.TemContct-Wppr').slideUp('slow');
        });

        // End Here 
        // Infrastructure page js 
        $('.InfrActyeMnu').owlCarousel({
            items: 1,
            loop: true,
            margin: 0,
            dots: true,
            autoplayTimeout: 4000,
            autoplayHoverPause: false,
            smartSpeed: 4000,
            slideSpeed: 4000,
            autoplay: false,
            nav: false,
            responsive: {
                0: {
                    items: 1,
                    margin: 0
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        });

        $('.GlbMrkBx span').click(function() {
            $(this).parents('.GlbMrkBx').siblings().find('.MrkAdrBx').slideUp('slow')
            $(this).parents('.GlbMrkBx').find('.MrkAdrBx').slideToggle('slow')
        });



    });


})();