/**
 * uikit Js library
 */
var uikitLib = window.uikitLib || {};

(function ($) {
    'use strict';

    // HTML > Replace < & >
    //------------------------
    function escapeHTML(html) {
        return html.replace(/ style=(".*?"|'.*?'|[^"'][^\s]*)/g,'').replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;');
    }
    
    // dataShow
    // 
    //------------------------
    // $.extend(uikitLib, {
    //     dataShow: {
    //         init: function(){
    //             $.ajaxSetup({ cache: false });
    //             $.getJSON('../data/locals.json', function( data ) {
    //                 $('#uikitPage').append(uikitLib.dataShow.buildHTML(data, true));

    //                 $(document).on('click', '.json-data .data-value', function(){
    //                     var jqThis = $(this),
    //                         value = jqThis.text();
    //                     if(jqThis.find('input').length == 0){
    //                         jqThis.text('').append('<input type="text" value="'+ value + '"/>');
    //                         jqThis.append('<span class="data-value-saved" style="display:none">' + value + '</span>');
    //                     }
    //                 });

    //                 $(document).on('change', '.json-data .data-value input', function(){
    //                     uikitLib.dataShow.showNav();
    //                 });

    //                 $(document).on('click', '[data-json="save"]', function(){
    //                     uikitLib.dataShow.saveValues();
    //                     uikitLib.dataShow.saveJSON();
    //                 });

    //                 $(document).on('click', '[data-json="cancel"]', function(){
    //                     uikitLib.dataShow.cancelValues();
    //                     uikitLib.dataShow.hideNav();
    //                 });
    //             });
    //         },
    //         showNav: function(){
    //             var jqJsonNavPanel = $('.json-nav-action');
    //             if(!jqJsonNavPanel.hasClass('show')){
    //                 jqJsonNavPanel.addClass('show');
    //             }
    //         },
    //         hideNav: function(){
    //             $('.json-nav-action').removeClass('show');
    //         },
    //         saveValues: function(){
    //             $('.json-data .data-value input').each(function(){
    //                 var jqThis = $(this),
    //                     value = jqThis.val();
    //                 jqThis.parent().html(value);
    //             })
    //         },
    //         cancelValues: function(){
    //             $('.json-data .data-value-saved').each(function(){
    //                 var jqThis = $(this);
    //                 jqThis.closest('.data-value').html(jqThis.text());
    //             })
    //         },
    //         saveJSON: function(){
    //             $.ajax({
    //                 url: '/json/save',
    //                 type: 'POST',
    //                 data: uikitLib.dataShow.buildJSON($('#jsonData')),
    //                 success: function(data) {
    //                     if(data == true){
    //                         var jqBtn = $('[data-json="save"]'),
    //                             btnText = jqBtn.text();
    //                         uikitLib.dataShow.hideNav();
    //                         $('.json-nav-action').before('<div class="json-save-success fade">Les données ont été sauvegardées !</div>')
    //                         $('.json-save-success').addClass('show');
    //                         setTimeout(function(){
    //                             $('.json-save-success').remove();
    //                         }, 2000);
    //                     }
    //                     else{
    //                         console.log(data);
    //                     }
    //                 }
    //             });
    //         },
    //         buildHTML: function(val, firstTime){
    //             var html = '';
    //             if(typeof val === 'object'){
    //                 html += '<ul class="json-data"' + (firstTime ? ' id="jsonData"' : '')  + '>';
    //                 Object.keys(val).forEach(function(key) {
    //                     html += '<li><strong class="data-key">' + key + '</strong> : ';
    //                     html += uikitLib.dataShow.buildHTML(val[key]);
    //                 });
    //                 html += '</li></ul>';
    //             }
    //             else{
    //                 html += '<span class="data-value">' + val + '</span>';
    //             }
    //             return html;
    //         },
    //         buildJSON: function(jqElem){
    //             var obj = {};
    //             jqElem.find('>li').each(function(){
    //                 var jqThis = $(this),
    //                     key = jqThis.find('> .data-key').text(),
    //                     val = jqThis.find('> .data-value').text(),
    //                     jqChild = jqThis.find('> ul');
    //                 if(jqChild.length > 0){
    //                     obj[key] = uikitLib.dataShow.buildJSON(jqChild);
    //                 }
    //                 else{
    //                     obj[key] = val;
    //                 }
    //             });
    //             return obj;
    //         }
    //     }
    // });

    $(document).ready(function () {
        var cssClassOpened = 'opened';

        // Toggle menu
        //------------------------
        $(document).on('click', '[data-uikit-toggle], .opened .scrollkit-toc a', function(){
            var jqElem = $(this),
                jqTarget = $(jqElem.data('uikitToggle'));

            if(!jqTarget.hasClass(cssClassOpened) && $('.' + cssClassOpened)){
                $('.' + cssClassOpened).toggleClass(cssClassOpened);
            }
            jqElem.toggleClass(cssClassOpened);
            jqTarget.toggleClass(cssClassOpened);
        });

        // Toggle
        $(document).on('click', '.uikit-toggle-btn', function(){
            $(this).next('.uikit-toggle-collapse').slideToggle();
        });


        //  Code generator
        //------------------------
        $('.uikit-preview').each(function() {
			var jqPreview = $(this),
                jqItem = jqPreview.closest('.uikit-item');

            // Generating code section
            jqPreview.before('<div class="uikit-tabs"><button type="button" class="uikit-btn active" data-uikit-toggle-tab>Preview</button><button type="button" class="uikit-btn" data-uikit-toggle-tab>HTML</button></div>')
                .after('<div class="uikit-code uikit-panel"><div class="uikit-code-wrapper"></div><button class="uikit-btn uikit-btn-dark uikit-btn-sm uikit-copy">Copy code to clipboard</button><textarea class="uikit-code-textarea"></textarea></div>')
                .wrap('<div class="uikit-panel active' + (jqPreview.hasClass('uikit-wrap') ? ' uikit-preview-wrapper' : '') + '"></div>');
            jqItem.find('.uikit-code-wrapper').html('<pre><code class="html">' + escapeHTML( jqPreview.html() ) + '</code></pre>');
        });
        
        $('.uikit-js').each(function() {
			var jqJS = $(this),
                jqItem = jqJS.closest('.uikit-item');

            // Generating code section
            jqJS.wrap('<div class="uikit-panel"></div>');
            jqItem.find('.uikit-tabs').append('<button type="button" class="uikit-btn" data-uikit-toggle-tab>JS</button>');
        });
        $('.uikit-item').each(function(){
            $(this).find('.uikit-panel').wrapAll('<div class="uikit-panels" />');
        });
        
        // Copy code to textarea
        $(document).on('click', '.uikit-copy', function() {
            var jqThis = $(this),
                jqItem = jqThis.closest('.uikit-item'),
                jqThisText = jqThis.text();

            jqItem.find('.uikit-code-textarea').text(jqItem.find('.uikit-code-wrapper').text()).select();
            document.execCommand('Copy');

            jqThis.text('Code copied !');
            setTimeout(function(){
                jqThis.text(jqThisText);
            }, 5000)
        });

        // Tabs
        $(document).on('click', '[data-uikit-toggle-tab]', function() {
            var jqItem = $(this).closest('.uikit-item');
            jqItem.find('.uikit-tabs button').removeClass('active');
            $(this).addClass('active');
            jqItem.find('.uikit-panel').removeClass('active');
            jqItem.find('.uikit-panel').eq($(this).index()).addClass('active');
        });


        // ScrollKit
        // TOC & GotoTop button
        //------------------------
        if (typeof ScrollKit === 'object') {
            ScrollKit.init({
                //scrollWrapper: '#uikitMainarea',
                superToc: {
                    source: '#uikit-page',
                	target: '#uikit-sidebar',
                    hasClass: 'uikit',
                    depth: 3,
                    start: 2
                },
                goTopButton: {
                    offsetTop: '100',
                    returnTo: '#uikit-page',
                    title: 'Go top',
                    icon: '&uarr;'
                },
                scrollMenu: {
                    offsetTop: '80',
                    fxEasing: 'easeOutExpo'
                }
            });
        }

        //  Code highlight
        //------------------------
        if(hljs){
            $('pre code').each(function(i, block) {
                hljs.highlightBlock(block);
            });
        }

        //  Progress demo
        //------------------------
        const demoProgressRadios = $('#progress-demo input');
        demoProgressRadios.on('change', function(){
            let percent = $(this).closest('.rvo-radio').find('label').text();
            $('.rvo-progress span').width(percent);
            $('.rvo-modal-progress').text(percent);
            if(percent == '100%'){
                $('.rvo-progress').removeClass('rvo-loading');
            } else {
                $('.rvo-progress').addClass('rvo-loading');
            }
        });

        //  addSnackBar demo
        //------------------------
        $('#addSnackBar').on('click', function(){
			$('<div class="rvo-snackbar"><div class="rvo-snackbar-text"> 5 nouveaux véhicules en cours de transport</div><div class="rvo-status rvo-success"></div><div class="rvo-snackbar-close"><button class="rvo-button-mini rvo-icon-delete rvo-shadowed" type="button" title="Fermer"></button></div></div>').appendTo('.rvo-snackbars');
			if( $('.rvo-snackbar').length > 3 ){
                $('.rvo-snackbar:first-child').remove();
            }
			$('.rvo-snackbar-close button').on('click', function(){ $(this).closest('.rvo-snackbar').remove() });
		})

    });
})(jQuery);