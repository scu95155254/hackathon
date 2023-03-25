/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "./_webassets/lightspeed/";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 84);
/******/ })
/************************************************************************/
/******/ ({

/***/ 0:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 1:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 25:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 31:
/***/ (function(module, exports) {

/*** IMPORTS FROM imports-loader ***/
(function() {
var jQuery = this.jQuery;
var jquery = jQuery;

'use strict';

var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; };

(function (window, document, undefined) {
    'use strict';

    (function (factory) {
        factory(window.jQuery);
    })(function ($) {
        // Create the defaults once
        var pluginName = 'pp_ln';
        var pluginClass = 'pp_ln';
        var pluginType = 'pp.ln';
        var defaults = {
            placement: 'auto',
            container: null,
            width: 'auto',
            height: 'auto',
            trigger: 'click', //hover,click,sticky,manual
            runStopPropagation: true,
            style: '',
            delay: {
                show: null,
                hide: 300
            },
            async: {
                type: 'GET',
                before: null, //function(that, xhr){}
                success: null, //function(that, xhr){}
                error: null //function(that, xhr, data){}
            },
            cache: true,
            multi: false,
            arrow: true,
            title: '',
            content: '',
            closeable: false,
            padding: true,
            url: '',
            type: 'html',
            direction: '', // ltr,rtl
            animation: null,
            template: '<div class="pp_ln">' + '<div class="arrow"></div>' + '<div class="pp_ln_inner">' + '<a href="#" class="close"></a>' + '<h3 class="pp_ln_title"></h3>' + '<div class="pp_ln_content"><i class="icon-refresh"></i> <p>&nbsp;</p></div>' + '</div>' + '</div>',
            backdrop: false,
            dismissible: true,
            onShow: null,
            onHide: null,
            abortXHR: true,
            autoHide: false,
            offsetTop: 0,
            offsetLeft: 0,
            iframeOptions: {
                frameborder: '0',
                allowtransparency: 'true',
                id: '',
                name: '',
                scrolling: '',
                onload: '',
                height: '',
                width: ''
            },
            hideEmpty: false
        };

        var rtlClass = pluginClass + '_rtl';
        var _srcElements = [];
        var backdrop = $('<div class="pp_ln_backdrop"></div>');
        var _globalIdSeed = 0;
        var _isBodyEventHandled = false;
        var _offsetOut = -2000; // the value offset  out of the screen
        var $document = $(document);

        var toNumber = function toNumber(numeric, fallback) {
            return isNaN(numeric) ? fallback || 0 : Number(numeric);
        };

        var getPopFromElement = function getPopFromElement($element) {
            return $element.data('plugin_' + pluginName);
        };

        var hideAllPop = function hideAllPop() {
            var pop = null;
            for (var i = 0; i < _srcElements.length; i++) {
                pop = getPopFromElement(_srcElements[i]);
                if (pop) {
                    pop.hide(true);
                }
            }
            $document.trigger('hiddenAll.' + pluginType);
        };

        var isMobile = 'ontouchstart' in document.documentElement && /Mobi/.test(navigator.userAgent);

        //var removeAllTargets = function() {
        // for (var i = 0; i < _srcElements.length; i++) {
        //     var pop = getPopFromElement(_srcElements[i]);
        //     console.log(pop.$target);
        // }
        //};

        var pointerEventToXY = function pointerEventToXY(e) {
            var out = {
                x: 0,
                y: 0
            };
            if (e.type === 'touchstart' || e.type === 'touchmove' || e.type === 'touchend' || e.type === 'touchcancel') {
                var touch = e.originalEvent.touches[0] || e.originalEvent.changedTouches[0];
                out.x = touch.pageX;
                out.y = touch.pageY;
            } else if (e.type === 'mousedown' || e.type === 'mouseup' || e.type === 'click') {
                out.x = e.pageX;
                out.y = e.pageY;
            }
            return out;
        };

        // The actual plugin constructor
        function WebuiPopover(element, options) {
            this.$element = $(element);
            if (options) {
                if ($.type(options.delay) === 'string' || $.type(options.delay) === 'number') {
                    options.delay = {
                        show: options.delay,
                        hide: options.delay
                    }; // bc break fix
                }
            }
            this.options = $.extend({}, defaults, options);
            this._defaults = defaults;
            this._name = pluginName;
            this._targetclick = false;
            this.init();
            _srcElements.push(this.$element);
        }

        WebuiPopover.prototype = {
            //init webui popover
            init: function init() {
                if (this.getTrigger() !== 'manual') {
                    //init the event handlers
                    if (this.getTrigger() === 'click' || isMobile) {
                        this.$element.off('click touchend').on('click touchend', $.proxy(this.toggle, this));
                    } else if (this.getTrigger() === 'hover') {
                        this.$element.off('mouseenter mouseleave click').on('mouseenter', $.proxy(this.mouseenterHandler, this)).on('mouseleave', $.proxy(this.mouseleaveHandler, this));
                    }
                }
                this._poped = false;
                this._inited = true;
                this._opened = false;
                this._idSeed = _globalIdSeed;
                // normalize container
                this.options.container = $(this.options.container || document.body).first();

                if (this.options.backdrop) {
                    backdrop.appendTo(this.options.container).hide();
                }
                _globalIdSeed++;
                if (this.getTrigger() === 'sticky') {
                    this.show();
                }
            },
            /* api methods and actions */
            destroy: function destroy() {
                var index = -1;

                for (var i = 0; i < _srcElements.length; i++) {
                    if (_srcElements[i] === this.$element) {
                        index = i;
                        break;
                    }
                }

                _srcElements.splice(index, 1);

                this.hide();
                this.$element.data('plugin_' + pluginName, null);
                if (this.getTrigger() === 'click') {
                    this.$element.off('click');
                } else if (this.getTrigger() === 'hover') {
                    this.$element.off('mouseenter mouseleave');
                }
                if (this.$target) {
                    this.$target.remove();
                }
            },
            /*
                param: force    boolean value, if value is true then force hide the popover
                param: event    dom event,
            */
            hide: function hide(force, event) {
                if (!force && this.getTrigger() === 'sticky') {
                    return;
                }
                if (!this._opened) {
                    return;
                }

                if (event) {
                    event.preventDefault();
                    this.options.runStopPropagation && event.stopPropagation();
                }

                if (this.xhr && this.options.abortXHR === true) {
                    this.xhr.abort();
                    this.xhr = null;
                }

                var e = $.Event('hide.' + pluginType);
                this.$element.trigger(e, [this.$target]);
                if (this.$target) {
                    this.$target.removeClass('in').addClass(this.getHideAnimation());
                    var that = this;
                    setTimeout(function () {
                        that.$target.hide();
                        if (!that.getCache()) {
                            that.$target.remove();
                        }
                    }, that.getHideDelay());
                }
                if (this.options.backdrop) {
                    backdrop.hide();
                }
                this._opened = false;
                this.$element.trigger('hidden.' + pluginType, [this.$target]);

                if (this.options.onHide) {
                    this.options.onHide(this.$target);
                }
            },
            resetAutoHide: function resetAutoHide() {
                var that = this;
                var autoHide = that.getAutoHide();
                if (autoHide) {
                    if (that.autoHideHandler) {
                        clearTimeout(that.autoHideHandler);
                    }
                    that.autoHideHandler = setTimeout(function () {
                        that.hide();
                    }, autoHide);
                }
            },
            toggle: function toggle(e) {
                if (e) {
                    e.preventDefault();
                    this.options.runStopPropagation && e.stopPropagation();
                }
                this[this.getTarget().hasClass('in') ? 'hide' : 'show']();
            },
            hideAll: function hideAll() {
                hideAllPop();
            },
            /*core method ,show popover */
            show: function show() {
                if (this._opened) {
                    return;
                }
                //removeAllTargets();
                var $target = this.getTarget().removeClass().addClass(pluginClass).addClass(this._customTargetClass);
                if (!this.options.multi) {
                    this.hideAll();
                }

                // use cache by default, if not cache setted  , reInit the contents
                if (!this.getCache() || !this._poped || this.content === '') {
                    this.content = '';
                    this.setTitle(this.getTitle());
                    if (!this.options.closeable) {
                        $target.find('.close').off('click').remove();
                    }

                    if (!this.isAsync()) {
                        this.setContent(this.getContent());
                    } else {
                        this.setContentASync(this.options.content);
                    }

                    if (this.canEmptyHide() && this.content === '') {
                        return;
                    }
                    $target.show();
                }

                this.displayContent();

                if (this.options.onShow) {
                    this.options.onShow($target);
                }

                this.bindBodyEvents();
                if (this.options.backdrop) {
                    backdrop.show();
                }
                this._opened = true;
                this.resetAutoHide();
            },
            displayContent: function displayContent() {
                var
                //element postion
                elementPos = this.getElementPosition(),

                //target postion
                $target = this.getTarget().removeClass().addClass(pluginClass).addClass(this._customTargetClass),

                //target content
                $targetContent = this.getContentElement(),

                //target Width
                targetWidth = $target[0].offsetWidth,

                //target Height
                targetHeight = $target[0].offsetHeight,

                //placement
                placement = 'bottom',
                    e = $.Event('show.' + pluginType);
                if (this.canEmptyHide()) {

                    var content = $targetContent.children().html();
                    if (content !== null && content.trim().length === 0) {
                        return;
                    }
                }

                //if (this.hasContent()){
                this.$element.trigger(e, [$target]);
                //}
                // support width as data attribute
                var optWidth = this.$element.data('width') || this.options.width;
                if (optWidth === '') {
                    optWidth = this._defaults.width;
                }

                if (optWidth !== 'auto') {
                    $target.outerWidth(optWidth);
                }

                // support height as data attribute
                var optHeight = this.$element.data('height') || this.options.height;
                if (optHeight === '') {
                    optHeight = this._defaults.height;
                }

                if (optHeight !== 'auto') {
                    $targetContent.outerHeight(optHeight);
                }
                if (this.options.style) {
                    if (typeof this.options.style === "string") {
                        console.log("string");
                        this.$target.addClass(pluginClass + '_' + this.options.style);
                    } else if (Array.isArray(this.options.style)) {
                        for (var i in this.options.style) {
                            this.$target.addClass(pluginClass + '_' + this.options.style[i]);
                        }
                    } else console.log('Wrong type of style!');
                }

                //check rtl
                if (this.options.direction === 'rtl' && !$targetContent.hasClass(rtlClass)) {
                    $targetContent.addClass(rtlClass);
                }

                //init the popover and insert into the document body
                if (!this.options.arrow) {
                    $target.find('.arrow').remove();
                }
                $target.detach().css({
                    top: _offsetOut,
                    left: _offsetOut,
                    display: 'block'
                });

                if (this.getAnimation()) {
                    $target.addClass(this.getAnimation());
                }
                $target.appendTo(this.options.container);

                placement = this.getPlacement(elementPos);

                //This line is just for compatible with knockout custom binding
                this.$element.trigger('added.' + pluginType);

                this.initTargetEvents();

                if (typeof this.options.padding === 'boolean' && !this.options.padding) {
                    if (this.options.height !== 'auto') {
                        $targetContent.css('height', $targetContent.outerHeight());
                    }
                    this.$target.addClass('pp_ln_nopadding');
                } else if (typeof this.options.padding === 'number' || typeof this.options.padding === 'string') {
                    $targetContent.css('padding', this.options.padding);
                }
                targetWidth = $target[0].offsetWidth;
                targetHeight = $target[0].offsetHeight;

                var postionInfo = this.getTargetPositin(elementPos, placement, targetWidth, targetHeight);

                this.$target.css(postionInfo.position).addClass(placement).addClass('in');

                if (this.options.type === 'iframe') {
                    var $iframe = $target.find('iframe');
                    var iframeWidth = $target.width();
                    var iframeHeight = $iframe.parent().height();

                    if (this.options.iframeOptions.width !== '' && this.options.iframeOptions.width !== 'auto') {
                        iframeWidth = this.options.iframeOptions.width;
                    }

                    if (this.options.iframeOptions.height !== '' && this.options.iframeOptions.height !== 'auto') {
                        iframeHeight = this.options.iframeOptions.height;
                    }

                    $iframe.width(iframeWidth).height(iframeHeight);
                }

                if (!this.options.arrow) {
                    this.$target.css({
                        'margin': 0
                    });
                }
                if (this.options.arrow) {
                    var $arrow = this.$target.find('.arrow');
                    $arrow.removeAttr('style');

                    //prevent arrow change by content size
                    if (placement === 'left' || placement === 'right') {
                        $arrow.css({
                            top: this.$target.height() / 2
                        });
                    } else if (placement === 'top' || placement === 'bottom') {
                        $arrow.css({
                            left: this.$target.width() / 2
                        });
                    }

                    if (postionInfo.arrowOffset) {
                        //hide the arrow if offset is negative
                        if (postionInfo.arrowOffset.left === -1 || postionInfo.arrowOffset.top === -1) {
                            $arrow.hide();
                        } else {
                            $arrow.css(postionInfo.arrowOffset);
                        }
                    }
                }
                this._poped = true;
                this.$element.trigger('shown.' + pluginType, [this.$target]);
            },

            isTargetLoaded: function isTargetLoaded() {
                return this.getTarget().find('i.glyphicon-refresh').length === 0;
            },

            /*getter setters */
            getTriggerElement: function getTriggerElement() {
                return this.$element;
            },
            getTarget: function getTarget() {
                if (!this.$target) {
                    var id = pluginName + this._idSeed;
                    this.$target = $(this.options.template).attr('id', id).data('trigger-element', this.getTriggerElement());
                    this._customTargetClass = this.$target.attr('class') !== pluginClass ? this.$target.attr('class') : null;
                    this.getTriggerElement().attr('data-target', id);
                }
                return this.$target;
            },
            getTitleElement: function getTitleElement() {
                return this.getTarget().find('.' + pluginClass + '_title');
            },
            getContentElement: function getContentElement() {
                if (!this.$contentElement) {
                    this.$contentElement = this.getTarget().find('.' + pluginClass + '_content');
                }
                return this.$contentElement;
            },
            getTitle: function getTitle() {
                return this.$element.attr('data-title') || this.options.title || this.$element.attr('title');
            },
            getUrl: function getUrl() {
                return this.$element.attr('data-url') || this.options.url;
            },
            getAutoHide: function getAutoHide() {
                return this.$element.attr('data-auto-hide') || this.options.autoHide;
            },
            getOffsetTop: function getOffsetTop() {
                return toNumber(this.$element.attr('data-offset-top')) || this.options.offsetTop;
            },
            getOffsetLeft: function getOffsetLeft() {
                return toNumber(this.$element.attr('data-offset-left')) || this.options.offsetLeft;
            },
            getCache: function getCache() {
                var dataAttr = this.$element.attr('data-cache');
                if (typeof dataAttr !== 'undefined') {
                    switch (dataAttr.toLowerCase()) {
                        case 'true':
                        case 'yes':
                        case '1':
                            return true;
                        case 'false':
                        case 'no':
                        case '0':
                            return false;
                    }
                }
                return this.options.cache;
            },
            getTrigger: function getTrigger() {
                return this.$element.attr('data-trigger') || this.options.trigger;
            },
            getDelayShow: function getDelayShow() {
                var dataAttr = this.$element.attr('data-delay-show');
                if (typeof dataAttr !== 'undefined') {
                    return dataAttr;
                }
                return this.options.delay.show === 0 ? 0 : this.options.delay.show || 100;
            },
            getHideDelay: function getHideDelay() {
                var dataAttr = this.$element.attr('data-delay-hide');
                if (typeof dataAttr !== 'undefined') {
                    return dataAttr;
                }
                return this.options.delay.hide === 0 ? 0 : this.options.delay.hide || 100;
            },
            getAnimation: function getAnimation() {
                var dataAttr = this.$element.attr('data-animation');
                return dataAttr || this.options.animation;
            },
            getHideAnimation: function getHideAnimation() {
                var ani = this.getAnimation();
                return ani ? ani + '-out' : 'out';
            },
            setTitle: function setTitle(title) {
                var $titleEl = this.getTitleElement();
                if (title) {
                    //check rtl
                    if (this.options.direction === 'rtl' && !$titleEl.hasClass(rtlClass)) {
                        $titleEl.addClass(rtlClass);
                    }
                    $titleEl.html(title);
                } else {
                    $titleEl.remove();
                }
            },
            hasContent: function hasContent() {
                return this.getContent();
            },
            canEmptyHide: function canEmptyHide() {
                return this.options.hideEmpty && this.options.type === 'html';
            },
            getIframe: function getIframe() {
                var $iframe = $('<iframe></iframe>').attr('src', this.getUrl());
                var self = this;
                $.each(this._defaults.iframeOptions, function (opt) {
                    if (typeof self.options.iframeOptions[opt] !== 'undefined') {
                        $iframe.attr(opt, self.options.iframeOptions[opt]);
                    }
                });

                return $iframe;
            },
            getContent: function getContent() {
                if (this.getUrl()) {
                    switch (this.options.type) {
                        case 'iframe':
                            this.content = this.getIframe();
                            break;
                        case 'html':
                            try {
                                this.content = $(this.getUrl());
                                if (!this.content.is(':visible')) {
                                    this.content.show();
                                }
                            } catch (error) {
                                throw new Error('Unable to get popover content. Invalid selector specified.');
                            }
                            break;
                    }
                } else if (!this.content) {
                    var content = '';
                    if ($.isFunction(this.options.content)) {
                        content = this.options.content.apply(this.$element[0], [this]);
                    } else {
                        content = this.options.content;
                    }
                    this.content = this.$element.attr('data-content') || content;
                    if (!this.content) {
                        var $next = this.$element.next();

                        if ($next && $next.hasClass(pluginClass + '_content')) {
                            this.content = $next;
                        }
                    }
                }
                return this.content;
            },
            setContent: function setContent(content) {
                var $target = this.getTarget();
                var $ct = this.getContentElement();
                if (typeof content === 'string') {
                    $ct.html(content);
                } else if (content instanceof $) {
                    $ct.html('');
                    //Don't want to clone too many times.
                    if (!this.options.cache) {
                        content.clone(true, true).removeClass(pluginClass + '_content').appendTo($ct);
                    } else {
                        content.removeClass(pluginClass + '_content').appendTo($ct);
                    }
                }
                this.$target = $target;
            },
            isAsync: function isAsync() {
                return this.options.type === 'async';
            },
            setContentASync: function setContentASync(content) {
                var that = this;
                if (this.xhr) {
                    return;
                }
                this.xhr = $.ajax({
                    url: this.getUrl(),
                    type: this.options.async.type,
                    cache: this.getCache(),
                    beforeSend: function beforeSend(xhr) {
                        if (that.options.async.before) {
                            that.options.async.before(that, xhr);
                        }
                    },
                    success: function success(data) {
                        that.bindBodyEvents();
                        if (content && $.isFunction(content)) {
                            that.content = content.apply(that.$element[0], [data]);
                        } else {
                            that.content = data;
                        }
                        that.setContent(that.content);
                        var $targetContent = that.getContentElement();
                        $targetContent.removeAttr('style');
                        that.displayContent();
                        if (that.options.async.success) {
                            that.options.async.success(that, data);
                        }
                    },
                    complete: function complete() {
                        that.xhr = null;
                    },
                    error: function error(xhr, data) {
                        if (that.options.async.error) {
                            that.options.async.error(that, xhr, data);
                        }
                    }
                });
            },

            bindBodyEvents: function bindBodyEvents() {
                if (_isBodyEventHandled) {
                    return;
                }
                if (this.options.dismissible && this.getTrigger() === 'click') {
                    $document.off('keyup.pp.ln').on('keyup.pp.ln', $.proxy(this.escapeHandler, this));
                    $document.off('click.pp.ln touchend.pp.ln').on('click.pp.ln touchend.pp.ln', $.proxy(this.bodyClickHandler, this));
                } else if (this.getTrigger() === 'hover') {
                    $document.off('touchend.pp.ln').on('touchend.pp.ln', $.proxy(this.bodyClickHandler, this));
                }
            },

            /* event handlers */
            mouseenterHandler: function mouseenterHandler() {
                var self = this;
                if (self._timeout) {
                    clearTimeout(self._timeout);
                }
                self._enterTimeout = setTimeout(function () {
                    if (!self.getTarget().is(':visible')) {
                        self.show();
                    }
                }, this.getDelayShow());
            },
            mouseleaveHandler: function mouseleaveHandler() {
                var self = this;
                clearTimeout(self._enterTimeout);
                //key point, set the _timeout  then use clearTimeout when mouse leave
                self._timeout = setTimeout(function () {
                    self.hide();
                }, this.getHideDelay());
            },
            escapeHandler: function escapeHandler(e) {
                if (e.keyCode === 27) {
                    this.hideAll();
                }
            },

            bodyClickHandler: function bodyClickHandler(e) {
                _isBodyEventHandled = true;
                var canHide = true;
                for (var i = 0; i < _srcElements.length; i++) {
                    var pop = getPopFromElement(_srcElements[i]);
                    if (pop && pop._opened) {
                        var offset = pop.getTarget().offset();
                        var popX1 = offset.left;
                        var popY1 = offset.top;
                        var popX2 = offset.left + pop.getTarget().width();
                        var popY2 = offset.top + pop.getTarget().height();
                        var pt = pointerEventToXY(e);
                        var inPop = pt.x >= popX1 && pt.x <= popX2 && pt.y >= popY1 && pt.y <= popY2;
                        if (inPop) {
                            canHide = false;
                            break;
                        }
                    }
                }
                if (canHide) {
                    hideAllPop();
                }
            },

            /*
            targetClickHandler: function() {
                this._targetclick = true;
            },
            */

            //reset and init the target events;
            initTargetEvents: function initTargetEvents() {
                if (this.getTrigger() === 'hover') {
                    this.$target.off('mouseenter mouseleave').on('mouseenter', $.proxy(this.mouseenterHandler, this)).on('mouseleave', $.proxy(this.mouseleaveHandler, this));
                }
                this.$target.find('.close').off('click').on('click', $.proxy(this.hide, this, true));
                //this.$target.off('click.pp_ln').on('click.pp_ln', $.proxy(this.targetClickHandler, this));
            },
            /* utils methods */
            //caculate placement of the popover
            getPlacement: function getPlacement(pos) {
                var placement,
                    container = this.options.container,
                    clientWidth = container.innerWidth(),
                    clientHeight = container.innerHeight(),
                    scrollTop = container.scrollTop(),
                    scrollLeft = container.scrollLeft(),
                    pageX = Math.max(0, pos.left - scrollLeft),
                    pageY = Math.max(0, pos.top - scrollTop);
                //arrowSize = 20;
                //if placement equals auto，caculate the placement by element information;
                if (typeof this.options.placement === 'function') {
                    placement = this.options.placement.call(this, this.getTarget()[0], this.$element[0]);
                } else {
                    placement = this.$element.data('placement') || this.options.placement;
                }

                var isH = placement === 'horizontal';
                var isV = placement === 'vertical';
                var detect = placement === 'auto' || isH || isV;

                if (detect) {
                    if (pageX < clientWidth / 3) {
                        if (pageY < clientHeight / 3) {
                            placement = isH ? 'right-bottom' : 'bottom-right';
                        } else if (pageY < clientHeight * 2 / 3) {
                            if (isV) {
                                placement = pageY <= clientHeight / 2 ? 'bottom-right' : 'top-right';
                            } else {
                                placement = 'right';
                            }
                        } else {
                            placement = isH ? 'right-top' : 'top-right';
                        }
                        //placement= pageY>targetHeight+arrowSize?'top-right':'bottom-right';
                    } else if (pageX < clientWidth * 2 / 3) {
                        if (pageY < clientHeight / 3) {
                            if (isH) {
                                placement = pageX <= clientWidth / 2 ? 'right-bottom' : 'left-bottom';
                            } else {
                                placement = 'bottom';
                            }
                        } else if (pageY < clientHeight * 2 / 3) {
                            if (isH) {
                                placement = pageX <= clientWidth / 2 ? 'right' : 'left';
                            } else {
                                placement = pageY <= clientHeight / 2 ? 'bottom' : 'top';
                            }
                        } else {
                            if (isH) {
                                placement = pageX <= clientWidth / 2 ? 'right-top' : 'left-top';
                            } else {
                                placement = 'top';
                            }
                        }
                    } else {
                        //placement = pageY>targetHeight+arrowSize?'top-left':'bottom-left';
                        if (pageY < clientHeight / 3) {
                            placement = isH ? 'left-bottom' : 'bottom-left';
                        } else if (pageY < clientHeight * 2 / 3) {
                            if (isV) {
                                placement = pageY <= clientHeight / 2 ? 'bottom-left' : 'top-left';
                            } else {
                                placement = 'left';
                            }
                        } else {
                            placement = isH ? 'left-top' : 'top-left';
                        }
                    }
                } else if (placement === 'auto-top') {
                    if (pageX < clientWidth / 3) {
                        placement = 'top-right';
                    } else if (pageX < clientWidth * 2 / 3) {
                        placement = 'top';
                    } else {
                        placement = 'top-left';
                    }
                } else if (placement === 'auto-bottom') {
                    if (pageX < clientWidth / 3) {
                        placement = 'bottom-right';
                    } else if (pageX < clientWidth * 2 / 3) {
                        placement = 'bottom';
                    } else {
                        placement = 'bottom-left';
                    }
                } else if (placement === 'auto-left') {
                    if (pageY < clientHeight / 3) {
                        placement = 'left-top';
                    } else if (pageY < clientHeight * 2 / 3) {
                        placement = 'left';
                    } else {
                        placement = 'left-bottom';
                    }
                } else if (placement === 'auto-right') {
                    if (pageY < clientHeight / 3) {
                        placement = 'right-top';
                    } else if (pageY < clientHeight * 2 / 3) {
                        placement = 'right';
                    } else {
                        placement = 'right-bottom';
                    }
                }
                return placement;
            },
            getElementPosition: function getElementPosition() {
                // If the container is the body or normal conatiner, just use $element.offset()
                var elRect = this.$element[0].getBoundingClientRect();
                var container = this.options.container;
                var cssPos = container.css('position');

                if (container.is(document.body) || cssPos === 'static') {
                    return $.extend({}, this.$element.offset(), {
                        width: this.$element[0].offsetWidth || elRect.width,
                        height: this.$element[0].offsetHeight || elRect.height
                    });
                    // Else fixed container need recalculate the  position
                } else if (cssPos === 'fixed') {
                    var containerRect = container[0].getBoundingClientRect();
                    return {
                        top: elRect.top - containerRect.top + container.scrollTop(),
                        left: elRect.left - containerRect.left + container.scrollLeft(),
                        width: elRect.width,
                        height: elRect.height
                    };
                } else if (cssPos === 'relative') {
                    return {
                        top: this.$element.offset().top - container.offset().top,
                        left: this.$element.offset().left - container.offset().left,
                        width: this.$element[0].offsetWidth || elRect.width,
                        height: this.$element[0].offsetHeight || elRect.height
                    };
                }
            },

            getTargetPositin: function getTargetPositin(elementPos, placement, targetWidth, targetHeight) {
                var pos = elementPos,
                    container = this.options.container,

                //clientWidth = container.innerWidth(),
                //clientHeight = container.innerHeight(),
                elementW = this.$element.outerWidth(),
                    elementH = this.$element.outerHeight(),
                    scrollTop = document.documentElement.scrollTop + container.scrollTop(),
                    scrollLeft = document.documentElement.scrollLeft + container.scrollLeft(),
                    position = {},
                    arrowOffset = null,
                    arrowSize = this.options.arrow ? 20 : 0,
                    padding = 10,
                    fixedW = elementW < arrowSize + padding ? arrowSize : 0,
                    fixedH = elementH < arrowSize + padding ? arrowSize : 0,
                    refix = 0,
                    pageH = document.documentElement.clientHeight + scrollTop,
                    pageW = document.documentElement.clientWidth + scrollLeft;

                var validLeft = pos.left + pos.width / 2 - fixedW > 0;
                var validRight = pos.left + pos.width / 2 + fixedW < pageW;
                var validTop = pos.top + pos.height / 2 - fixedH > 0;
                var validBottom = pos.top + pos.height / 2 + fixedH < pageH;

                switch (placement) {
                    case 'bottom':
                        position = {
                            top: pos.top + pos.height,
                            left: pos.left + pos.width / 2 - targetWidth / 2
                        };
                        break;
                    case 'top':
                        position = {
                            top: pos.top - targetHeight,
                            left: pos.left + pos.width / 2 - targetWidth / 2
                        };
                        break;
                    case 'left':
                        position = {
                            top: pos.top + pos.height / 2 - targetHeight / 2,
                            left: pos.left - targetWidth
                        };
                        break;
                    case 'right':
                        position = {
                            top: pos.top + pos.height / 2 - targetHeight / 2,
                            left: pos.left + pos.width
                        };
                        break;
                    case 'top-right':
                        position = {
                            top: pos.top - targetHeight,
                            left: validLeft ? pos.left - fixedW : padding
                        };
                        arrowOffset = {
                            left: validLeft ? Math.min(elementW, targetWidth) / 2 + fixedW : _offsetOut
                        };
                        break;
                    case 'top-left':
                        refix = validRight ? fixedW : -padding;
                        position = {
                            top: pos.top - targetHeight,
                            left: pos.left - targetWidth + pos.width + refix
                        };
                        arrowOffset = {
                            left: validRight ? targetWidth - Math.min(elementW, targetWidth) / 2 - fixedW : _offsetOut
                        };
                        break;
                    case 'bottom-right':
                        position = {
                            top: pos.top + pos.height,
                            left: validLeft ? pos.left - fixedW : padding
                        };
                        arrowOffset = {
                            left: validLeft ? Math.min(elementW, targetWidth) / 2 + fixedW : _offsetOut
                        };
                        break;
                    case 'bottom-left':
                        refix = validRight ? fixedW : -padding;
                        position = {
                            top: pos.top + pos.height,
                            left: pos.left - targetWidth + pos.width + refix
                        };
                        arrowOffset = {
                            left: validRight ? targetWidth - Math.min(elementW, targetWidth) / 2 - fixedW : _offsetOut
                        };
                        break;
                    case 'right-top':
                        refix = validBottom ? fixedH : -padding;
                        position = {
                            top: pos.top - targetHeight + pos.height + refix,
                            left: pos.left + pos.width
                        };
                        arrowOffset = {
                            top: validBottom ? targetHeight - Math.min(elementH, targetHeight) / 2 - fixedH : _offsetOut
                        };
                        break;
                    case 'right-bottom':
                        position = {
                            top: validTop ? pos.top - fixedH : padding,
                            left: pos.left + pos.width
                        };
                        arrowOffset = {
                            top: validTop ? Math.min(elementH, targetHeight) / 2 + fixedH : _offsetOut
                        };
                        break;
                    case 'left-top':
                        refix = validBottom ? fixedH : -padding;
                        position = {
                            top: pos.top - targetHeight + pos.height + refix,
                            left: pos.left - targetWidth
                        };
                        arrowOffset = {
                            top: validBottom ? targetHeight - Math.min(elementH, targetHeight) / 2 - fixedH : _offsetOut
                        };
                        break;
                    case 'left-bottom':
                        position = {
                            top: validTop ? pos.top - fixedH : padding,
                            left: pos.left - targetWidth
                        };
                        arrowOffset = {
                            top: validTop ? Math.min(elementH, targetHeight) / 2 + fixedH : _offsetOut
                        };
                        break;

                }
                position.top += this.getOffsetTop();
                position.left += this.getOffsetLeft();

                return {
                    position: position,
                    arrowOffset: arrowOffset
                };
            }
        };
        $.fn[pluginName] = function (options, noInit) {
            var results = [];
            var $result = this.each(function () {

                var webuiPopover = $.data(this, 'plugin_' + pluginName);
                if (!webuiPopover) {
                    if (!options) {
                        webuiPopover = new WebuiPopover(this, null);
                    } else if (typeof options === 'string') {
                        if (options !== 'destroy') {
                            if (!noInit) {
                                webuiPopover = new WebuiPopover(this, null);
                                results.push(webuiPopover[options]());
                            }
                        }
                    } else if ((typeof options === 'undefined' ? 'undefined' : _typeof(options)) === 'object') {
                        webuiPopover = new WebuiPopover(this, options);
                    }
                    $.data(this, 'plugin_' + pluginName, webuiPopover);
                } else {
                    if (options === 'destroy') {
                        webuiPopover.destroy();
                    } else if (typeof options === 'string') {
                        results.push(webuiPopover[options]());
                    }
                }
            });
            return results.length ? results : $result;
        };

        //Global object exposes to window.
        var popovers = function () {
            var _hideAll = function _hideAll() {
                hideAllPop();
            };
            var _create = function _create(selector, options) {
                options = options || {};
                $(selector).pp_ln(options);
            };
            var _isCreated = function _isCreated(selector) {
                var created = true;
                $(selector).each(function (item) {
                    created = created && $(item).data('plugin_' + pluginName) !== undefined;
                });
                return created;
            };
            var _show = function _show(selector, options) {
                if (options) {
                    $(selector).pp_ln(options).pp_ln('show');
                } else {
                    $(selector).pp_ln('show');
                }
            };
            var _hide = function _hide(selector) {
                $(selector).pp_ln('hide');
            };
            return {
                show: _show,
                hide: _hide,
                create: _create,
                isCreated: _isCreated,
                hideAll: _hideAll
            };
        }();
        window.pp_ln = popovers;
    });
})(window, document);
}.call(window));

/***/ }),

/***/ 37:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 38:
/***/ (function(module, exports) {

/*** IMPORTS FROM imports-loader ***/
(function() {
var jQuery = this.jQuery;
var jquery = jQuery;

'use strict';

var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; };

(function ($) {
    'use strict';

    var ModuleName = 'ntb_gplt';

    var Module = function Module(element, options) {
        this.ele = element;
        this.option = options;
        this.$ele = $(element);
        this.$tabsWrap = this.$ele.children('.ntb-tabs');
        this.$tabs = this.$tabsWrap.children('li');
        this.$leftArrow = $('<div class="left-arrow"></div>');
        this.$rightArrow = $('<div class="right-arrow"></div>');
        this.scrollPosition = [];
    };

    Module.DEFAULTS = {
        openAnimate: null,
        closeAnimate: null,
        clickTabToClose: false,
        enableTabScrollbar: false,
        enableTabArrow: false,
        cssClass: {
            tabScrollbar: 'ntb_scroll_tabs'
        },
        whenOpen: function whenOpen($tab, $content) {},
        whenClose: function whenClose($tab, $content) {},
        whenInited: function whenInited($tab, $this, $tabs) {}

    };

    Module.prototype.init = function () {
        var self = this;
        var $this = this.$ele;
        var opt = this.option;
        var $tabs = $this.children('.ntb-tabs');
        var $active = $this.children('.ntb-tabs').find('.ntb-tab.active, .ntb-tab:checked');
        var $activeContent = $active.closest('.ntb_gplt').children('.ntb-content[name=' + $active.attr('data-toggle') + ']');
        var $closeBtn = $this.find('.ntb-close');
        this.arrowJudgment();
        this.renderTab();
        var $tab = $tabs.find('.ntb-tab').add($this.children(".ntb-tab"));
        if (this.option.enableTabScrollbar === true) {
            this.enableTabScrollbar();
        }
        if (this.option.enableTabArrow === true) {
            this.enableTabArrow();
        }
        if ($active.is(':checked')) {
            $active.addClass('active');
        }
        $activeContent.addClass('active').show();
        opt.whenInited($tab, $this, $tabs);
        $tab.click(function (e) {
            // console.log("clicked")
            self.toggleContent($(this));
        });

        $closeBtn.click(function () {
            var $content = $(this).closest('.ntb-content');
            var $thisTab = $(this).closest('.ntb_gplt').children('.ntb-tabs').find('.ntb-tab[data-toggle=' + $content.attr('name') + ']');
            $(this).closest('.ntb-content').slideUp();
            $thisTab.removeClass('active');
            $content.removeClass('active');
            if (opt.whenClose && typeof opt.whenClose === 'function') {
                opt.whenClose($thisTab, $content);
            }
        });

        $this.on('close', function (e, name) {
            e.stopPropagation();
            if (name && typeof name === 'string') {
                var $tab = $this.children('.ntb-tabs').find('.ntb-tab[data-toggle=' + name + ']').add($this.children(".ntb-tab").filter('.ntb-tab[data-toggle=' + name + ']'));
                var $content = $this.children('.ntb-content[name=' + name + ']');
                // console.log("$tab", $tab)
                $tab.removeClass('active');
                $content.removeClass('active');
                if (opt.closeAnimate && opt.closeAnimate == 'slide') {
                    $content.slideUp();
                } else {
                    $content.hide();
                }
                if (opt.whenClose && typeof opt.whenClose === 'function') {
                    opt.whenClose($tab, $content);
                }
            }
        });

        $this.on('open', function (e, name) {
            e.stopPropagation();
            if (name && typeof name === 'string') {
                var $tab = $this.children('.ntb-tabs').find('.ntb-tab[data-toggle=' + name + ']').add($this.children(".ntb-tab").filter('.ntb-tab[data-toggle=' + name + ']'));
                var $content = $this.children('.ntb-content[name=' + name + ']');

                $tab.addClass('active');
                $content.addClass('active');
                if (opt.openAnimate && opt.openAnimate == 'slide') {
                    $content.slideDown();
                } else {
                    $content.show();
                }
                if (opt.whenOpen && typeof opt.whenOpen === 'function') {
                    opt.whenOpen($tab, $content);
                }
            }
        });
    };

    Module.prototype.toggleContent = function ($tab) {
        var $this = this.$ele;
        var opt = this.option;
        var $tabs = $this.children('.ntb-tabs').add($this.children(".ntb-tab"));
        var $active = $this.children('.ntb-tabs').find('.ntb-tab.active, .ntb-tab:checked');
        if ($tab.hasClass('active')) {
            if (opt.clickTabToClose) {
                $this.trigger('close', [$tab.attr('data-toggle')]);
            }
        } else {
            $active = $tabs.find('.ntb-tab.active');
            if ($active.length > 0) {
                $this.trigger('close', [$active.attr('data-toggle')]);
            }
            $this.trigger('open', [$tab.attr('data-toggle')]);
        }
    };

    Module.prototype.enableTabScrollbar = function () {
        if (typeof this.option.enableTabScrollbar === 'boolean' && this.option.enableTabScrollbar === true) {
            this.$ele.addClass(this.option.cssClass.tabScrollbar);
        } else {
            console.log('Module option is not allow enable');
        }
    };

    Module.prototype.enableTabArrow = function () {
        var self = this;
        this.setScrollPosition();
        if (typeof this.option.enableTabArrow === 'boolean' && this.option.enableTabArrow === true) {
            this.$ele.addClass('ntb_arrow').children('.ntb-tabs').before(this.$leftArrow).after(this.$rightArrow);
            this.$leftArrow.on('click', function (e) {
                self.arrowPrev();
            });
            this.$rightArrow.on('click', function (e) {
                self.arrowNext();
            });
        } else {
            console.log('Module option is not allow enable');
        }
    };

    Module.prototype.setScrollPosition = function () {
        var self = this;
        this.$tabs.each(function (index, el) {
            var $this = $(el);
            self.scrollPosition.push($this.outerWidth());
        });
    };

    Module.prototype.arrowNext = function () {
        var nowScrollLeft = this.$tabsWrap.scrollLeft();
        var scrollSum = 0;
        for (var i = 0; i < this.scrollPosition.length && scrollSum <= nowScrollLeft; i++) {
            scrollSum += this.scrollPosition[i];
            this.$tabsWrap.scrollLeft(scrollSum);
        }
    };

    Module.prototype.arrowPrev = function () {
        var nowScrollLeft = this.$tabsWrap.scrollLeft();
        var scrollSum = this.scrollPosition.reduce(function (acc, val) {
            return acc + val;
        }, 0);
        for (var i = this.scrollPosition.length - 1; i >= 0 && scrollSum >= nowScrollLeft; i--) {
            scrollSum -= this.scrollPosition[i];
            this.$tabsWrap.scrollLeft(scrollSum);
        }
    };

    Module.prototype.renderTab = function () {
        var $this = this.$ele;
        var $contents = $this.children('.ntb-content');
        if ($this.hasClass('ntb-xs-stack')) {
            // console.log("hasClass('ntb-xs-stack')")
            $contents.each(function () {
                var $tab = $this.children('.ntb-tabs').find('.ntb-tab[data-toggle=' + $(this).attr('name') + ']').parent().html();
                $(this).before($tab);
                // console.log("$tab", $tab)
            });
        }
    };
    Module.prototype.arrowJudgment = function () {
        var $this = this.$ele;
        if ($this.hasClass('ntb_scroll')) {
            this.scrollHidden();
        }
    };
    Module.prototype.scrollHidden = function () {
        var $this = this.$ele;
        var $left = $this.children('.left-arrow');
        var $right = $this.children('.right-arrow');
        var $width = $this.children('.ntb-tabs')[0].clientWidth;
        var $scrollWidth = $this.children('.ntb-tabs')[0].scrollWidth;
        var $outSideWidth = $('.ntb_scroll')[0].scrollWidth;
        $left.addClass('btn-hidden');
        $this.find('.ntb-tabs').scroll(function () {
            if ($(this).scrollLeft() == 0) {
                $left.addClass('btn-hidden');
                $right.removeClass('btn-hidden');
            } else if ($scrollWidth - $width == Math.ceil($(this).scrollLeft())) {
                $left.removeClass('btn-hidden');
                $right.addClass('btn-hidden');
            } else if ($scrollWidth - $width !== Math.ceil($(this).scrollLeft())) {
                $left.removeClass('btn-hidden');
                $right.removeClass('btn-hidden');
            }
        });
        if ($outSideWidth >= $scrollWidth) {
            $right.addClass('btn-hidden');
        }
    };

    $.fn[ModuleName] = function (options, options2) {
        return this.each(function () {
            var $this = $(this);
            var module = $this.data(ModuleName);
            var opts = {};
            if (!!module) {
                if (typeof options === 'string' && typeof options2 === 'undefined') {
                    module[options]();
                } else if (typeof options === 'string' && (typeof options2 === 'undefined' ? 'undefined' : _typeof(options2)) === 'object') {
                    module[options](options2);
                } else {
                    console.log('unsupported options!');
                }
            } else {
                opts = $.extend(true, {}, Module.DEFAULTS, (typeof options === 'undefined' ? 'undefined' : _typeof(options)) === 'object' && options, (typeof options2 === 'undefined' ? 'undefined' : _typeof(options2)) === 'object' && options2);
                module = new Module(this, opts);
                $this.data(ModuleName, module);
                module.init();
            }
        });
    };
})(jQuery);
}.call(window));

/***/ }),

/***/ 4:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 84:
/***/ (function(module, exports, __webpack_require__) {

/*** IMPORTS FROM imports-loader ***/
(function() {
var jQuery = this.jQuery;
var jquery = jQuery;

'use strict';

__webpack_require__(85);

__webpack_require__(0);

__webpack_require__(1);

__webpack_require__(25);

__webpack_require__(86);

__webpack_require__(4);

__webpack_require__(87);

__webpack_require__(37);

__webpack_require__(38);

__webpack_require__(31);
}.call(window));

/***/ }),

/***/ 85:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 86:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 87:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ })

/******/ });