// (function ($) {

    /**
     *  Function library
     *  ------------------------------------------------
     */



    /**
     *  After page loading
     *  ------------------------------------------------
     */
	$.when( $.ready ).then(function() { 

        /*---------------------------------
         *  Common constiables
         *---------------------------------*/
		const openedClassName = 'rvo-opened',
			closedClassName = 'rvo-closed',
			activeClassName = 'rvo-active';

		/*---------------------------------
		 *  Mobile Topnav
		 *---------------------------------*/

		/*---------------------------------
		 *  Forms
		 *---------------------------------*/
		const formElementsToFocus = $('.rvo-field input, .rvo-field textarea'),
			focusedClassName = 'rvo-focused';

		formElementsToFocus.on('focusin', function(){
			$(this).closest('.rvo-field').addClass(focusedClassName);
		});
		formElementsToFocus.on('focusout', function(){
			$(this).closest('.rvo-field').removeClass(focusedClassName);
		});
		
		/*---------------------------------
		 *  MainNav
		 *---------------------------------*/
		const mainNav = $('#rvo-mainnav'),
			mainNavTrigger = $('#rvo-mainnav-trigger');

		mainNavTrigger.on('click', function(){
			$('ul', mainNav).toggleClass(openedClassName);
			$(this).toggleClass(openedClassName);
		});
		mainNav.on('click', function(e) {
			e.stopPropagation();
		});
		$('body').on('click', function() {
			$('ul', mainNav).removeClass(openedClassName);
			mainNavTrigger.removeClass(openedClassName);
		});
		
		/*---------------------------------
		 *  User nav
		 *---------------------------------*/
		const userNav = $('#rvo-user-nav'),
			userNavTrigger = $('#rvo-user-image');

		userNavTrigger.on('click', function(){
			userNav.toggleClass(openedClassName);
		});
		$('#rvo-user').on('click', function(e) {
			e.stopPropagation();
		});
		$('body').on('click', function() {
			userNav.removeClass(openedClassName);
		});

		/*---------------------------------
		 *  DropDown (CSS3)
		 *---------------------------------*/
		$('.rvo-ddown-trigger').on('click', function(event) {
			const self = $(this);
			self.closest('.rvo-ddown').stop().toggleClass(openedClassName);
			self.closest('.rvo-stickycol').stop().toggleClass('rvo-has-opened-elems');
			return false;
		});

		$('.rvo-ddown-target').on('click', function(e) {
			e.stopPropagation();
		});

		$('.rvo-ddown:not(".rvo-isfilter") .rvo-ddown-item').on('click', function() {
			$(this).closest('.rvo-ddown').find('.rvo-current').removeClass('rvo-current');
			$(this).closest('.rvo-stickycol').stop().toggleClass('rvo-has-opened-elems');
			$(this).addClass('rvo-current').closest('.rvo-ddown').stop().toggleClass(openedClassName).find('.rvo-ddown-trigger-text').text($(this).text());
			if ( $(this).find('.rvo-item-radio') ){
				$(this).closest('.rvo-ddown').find('.rvo-ddown-trigger-text').prepend('<span class="rvo-trigger-radio">')
			}
		});

		$('body').on('click', function() {
			$('.rvo-ddown').removeClass(openedClassName);
		});

		/*---------------------------------
		 *  Autocomplete
		 *---------------------------------*/
		$('.rvo-autocomplete').each(function(){
			const self = $(this),
				input = $(this).closest('.rvo-field').find('input');
				
			input.on('focusin', function(){
				self.addClass(openedClassName);
			});
			input.on('focusout', function(){
				self.removeClass(openedClassName);
			});
		});
		
		/*---------------------------------
		 *  Menu
		 *---------------------------------*/
		$('[data-menu-trigger]').on('click', function() {
			let menu = $(this).attr('data-menu-trigger');
			$('.rvo-menu').stop().removeClass(openedClassName);
			$('.rvo-menu[data-menu="'+menu+'"]').stop().toggleClass(openedClassName);
		});

		$('[data-menu-trigger]').on('click', function(e) {
			e.stopPropagation();
		});
		
		$('body').on('click', function() {
			$('.rvo-menu').removeClass(openedClassName);
		});

		/*---------------------------------
		 *  Bookmark button
		 *---------------------------------*/
		$('.rvo-icon-bookmark-fill').on('click', function(){
			$(this).toggleClass('rvo-selected')
		});

		/*---------------------------------
		 *  Tabs
		 *---------------------------------*/
		const tabs = $('.rvo-tabs'),
			tabsNav = $('.rvo-tabs-nav'),
			tabsNavItem = $('.rvo-tabs-nav-item'),
			tabsPanel = $('.rvo-tabs-panel'),
			tabsNavFollower = $('.rvo-tabs-follower');
		
		moveFollower = function(tabsNavItem){
			const tabsNavItemPosition = tabsNavItem.position(),
				tabsNavItemWidth = tabsNavItem.outerWidth();
			tabsNavItem.closest(tabs).find(tabsNavFollower).css({
				'left' : tabsNavItemPosition.left + 40,
				'width' : tabsNavItemWidth
			});
		}
		tabsNavItem.on('click', function(){
			const self = $(this),
				closestTabs = self.closest(tabs);

			closestTabs.find(tabsNavItem).removeClass(openedClassName);
			self.addClass(openedClassName);
			
			self.closest(tabs).find(tabsPanel).removeClass(openedClassName);
			closestTabs.find(tabsPanel).eq(self.index()).addClass(openedClassName);
			moveFollower(self)
		});
		tabsNav.each(function(){
			const self = $(this);
			self.find(tabsNavItem).eq(0).addClass(openedClassName);
			self.closest(tabs).find(tabsPanel).eq(0).addClass(openedClassName);
			moveFollower(self.find(tabsNavItem).eq(0));
		});

		/*---------------------------------
		*  Modals
		*---------------------------------*/
		var modal = $('.rvo-modal');

		modal.each(function(){
			var self = $(this),
				modalFrame = $('.rvo-modal-frame', self),
				modalClose = $('.rvo-modal-close', self),
				modalTargetId = self.data('modal');

			$('[data-modal-trigger="'+modalTargetId+'"]').on('click', function(){
				self.addClass(openedClassName);
			});
			self.on('click', function(){
				self.removeClass(openedClassName);
			});
			modalClose.on('click', function(){
				self.removeClass(openedClassName);
			});
			modalFrame.on('click', function(e){
				e.stopPropagation();
			});
			
		});

		/*---------------------------------
		*  Table sticky
		*---------------------------------*/
		function stickyCols(){
			$('.rvo-table-cell.rvo-stickycol').each(function(){
				let stickyCell = $(this);
				stickyCell.css('left', '');
				let position = stickyCell.position();
				stickyCell.css('left', position.left)
			});
		}
		stickyCols();
		$( window ).resize(function() {
			console.log('resize')
			stickyCols();
		});
		/*---------------------------------
		*  Table Toggle
		*---------------------------------*/
		$('.rvo-table-cell-toggle button').on('click', function(){
			let parentRow = $(this).closest('tr');
			let trigger = parentRow.attr('data-row-toggle');
			parentRow.toggleClass(openedClassName);
			$('.rvo-table-row-target[data-row-toggle="'+trigger+'"]').toggleClass(openedClassName);
			let title = $(this).attr('title');
			$(this).attr('title', title == 'Afficher les détails' ? 'Masquer les détails' : 'Afficher les détails' );
		});

		/*---------------------------------
		*  Table Sort
		*---------------------------------*/
		$('.rvo-table-header-sort').on('click', function(){
			let headerSort= $(this);
			if( headerSort.hasClass('rvo-descending') ){
				headerSort.removeClass('rvo-descending').addClass('rvo-ascending')
			} else if( headerSort.hasClass('rvo-ascending') ){
				headerSort.removeClass('rvo-ascending')
			} else{
				headerSort.addClass('rvo-descending')
			}
		});

		/*---------------------------------
		*  Snackbar
		*---------------------------------*/
		$('.rvo-snackbar-close button').on('click', function(){ $(this).closest('.rvo-snackbar').remove() });

		/*---------------------------------
		*  Filters
		*---------------------------------*/
		$('[data-filter-toggle="open"]').on('click', function(){
			$(this).hide();
			$('.rvo-filters-active').hide();
			$('.rvo-filters-ddowns').show();
			$('[data-filter-toggle="close"]').show();
		});
		$('[data-filter-toggle="close"]').on('click', function(){
			$(this).hide();
			$('.rvo-filters-active').show();
			$('.rvo-filters-ddowns').hide();
			$('[data-filter-toggle="open"]').show();
		});
		$('.rvo-ddown-item label').on('click', function() {
			$('<button class="rvo-filter-tag"><span class="rvo-filter-tag-label">'+$(this).text()+'</span><span class="rvo-icon-delete"></span></button>').appendTo('.rvo-filters-tags');
			if($('.rvo-filters-tags').length>0){
				$('.rvo-filters-reset').show();
			} else{
				$('.rvo-filters-reset').hide();
			}
			$('.rvo-filter-tag').on('click', function(){
				$(this).remove();
			});
		});
		$('.rvo-filters-reset button').on('click', function(){
			$(this).hide();
			$('.rvo-filter-tag').remove();
		});


		/*---------------------------------
		*  Confirm button
		*---------------------------------*/
		const range = $('.rvo-confirm input')
		range.on('input', function(){
			moveConfirmButton(parseInt(range.val()))
			if(range.val() == 70){
				$('.rvo-confirm').addClass('rvo-success');
			} else{
				$('.rvo-confirm').removeClass('rvo-success');
			}
		})
		range.on('change', function(){
			if(range.val() < 70){
				range.val(0);
				moveConfirmButton(0);
			}
		})
		function moveConfirmButton(val){
			const confirmButton = $('.rvo-confirm .rvo-button')
			confirmButton.css('margin-left', val+'%')
		}

// })(jQuery);

/*---------------------------------
*  sliderAvatar
*---------------------------------*/
const sliderAvatar = document.querySelector('.rvo-slider-avatar'),
	sliderAvatarPrev = sliderAvatar.querySelector('.rvo-slider-prev'),
	sliderAvatarNext = sliderAvatar.querySelector('.rvo-slider-next'),
	sliderAvatarItems = sliderAvatar.querySelector('.rvo-slider-items'),
	sliderAvatarItem = sliderAvatarItems.querySelectorAll('.rvo-slider-item'),
	sliderAvatarItemLength = sliderAvatarItem.length,
	sliderAvatarItemWidth = sliderAvatarItem[0].offsetWidth,
	disabledClassName = 'rvo-disbaled';

let sliderAvatarItemCurrentIndex = 0; // 0 Based

function slideToCurrent(){
	if( sliderAvatarItemCurrentIndex == 0 ){
		sliderAvatarPrev.classList.add('rvo-disabled');
		sliderAvatarItems.style.left = sliderAvatarItemWidth * (sliderAvatarItemCurrentIndex + 1) + 'px';
	} else {
		sliderAvatarPrev.classList.remove('rvo-disabled');
		sliderAvatarItems.style.left = -sliderAvatarItemWidth * (sliderAvatarItemCurrentIndex - 1) + 'px';
	}
	if( (sliderAvatarItemCurrentIndex + 1) == sliderAvatarItemLength ){
		sliderAvatarNext.classList.add('rvo-disabled');
	} else{
		sliderAvatarNext.classList.remove('rvo-disabled');
	}
	for (i=0;i<sliderAvatarItem.length;i++) {
		sliderAvatarItem[i].classList.remove('rvo-current');
	}
	sliderAvatarItem[sliderAvatarItemCurrentIndex].classList.add('rvo-current');
}
slideToCurrent();

sliderAvatarPrev.addEventListener('click', function(){
	sliderAvatarItemCurrentIndex = sliderAvatarItemCurrentIndex - 1;
	slideToCurrent();
});

sliderAvatarNext.addEventListener('click', function(){
	sliderAvatarItemCurrentIndex = sliderAvatarItemCurrentIndex + 1;
	slideToCurrent();
});


});

/*---------------------------------
*  Dropzone
*---------------------------------*/
// On button click
function dropInputTrigger(ev, drop) {
	var fileInput = drop.querySelector(".rvo-dropzone-input input");
	fileInput.click();
}

// Get Files name
function getFilesName(drop){
	var fileInput = drop.querySelector(".rvo-dropzone-input input");
	if (fileInput.files.length > 0){
		for (var i=0; i < fileInput.files.length; i++) {
			var f = fileInput.files.item(i);
			var dropFiles = drop.querySelector('.rvo-dropfiles')
			dropFiles.insertAdjacentHTML("beforeend", '<div class="rvo-file"><span class="rvo-icon-attachement"></span><span class="rvo-file-name">'+f.name+'</span><button class="rvo-file-delete" onclick="removeFile(this);"></button></div>')
		}
	}
}

// On drop file
function dropOnDrop(ev, drop) {
	ev.preventDefault();
	// If dropped items aren't files, reject them
	var dt = ev.dataTransfer;
	if (dt.items) {
		// Use DataTransferItemList interface to access the file(s)
		for (var i=0; i < dt.items.length; i++) {
			var file = dt.items[i];
			var dropFiles = drop.querySelector('.rvo-dropfiles');
			if (file.kind == "file" && ( file.type == "application/pdf" || file.type == "text/csv" || file.type == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") ) {
				var file = file.getAsFile();
				dropFiles.insertAdjacentHTML("beforeend", '<div class="rvo-file"><span class="rvo-icon-attachement"></span><span class="rvo-file-name">'+file.name+'</span><button class="rvo-file-delete" onclick="removeFile(this);"></button></div>')
			} else {
				var file = file.getAsFile();
				dropFiles.insertAdjacentHTML("beforeend", '<div class="rvo-file rvo-invalid"><span class="rvo-icon-attachement"></span><span class="rvo-file-name">'+file.name+'</span><i>Ce type de fichier n\'est pas accepté</div>')
			}
		}
	}

	drop.querySelector('.rvo-dropzone').classList.remove('rvo-ondrop');
}

// On drag hover
function dropOnDragHover(ev, drop) {
	ev.preventDefault();
	drop.querySelector('.rvo-dropzone').classList.add('rvo-ondrop');
	var dt = ev.dataTransfer;
}

// On drag leave
function dropOnDragLeave(ev, drop) {
	ev.preventDefault();
	drop.querySelector('.rvo-dropzone').classList.remove('rvo-ondrop');
}

// On drag end
function dropOnDragEnd(ev) {
	// Remove all of the drag data
	var dt = ev.dataTransfer;
	if (dt.items) {
		for (var i = 0; i < dt.items.length; i++) {
			dt.items.remove(i);
		}
	} 

	document.querySelector('.rvo-dropzone').classList.remove('rvo-ondrop');

}

//- Remove files
function removeFile(element){
	element.parentElement.remove();
}

