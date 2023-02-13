(function ($) {
    $.fn.CBTautocomplete = function (options) {
        var settings = $.extend({
            width: 300,
            maxHeight: 370,
            data: [],
            column: [],
            xsHiddenCol: [],
            sHiddenCol: [],
            mHiddenCol: [],
            lHiddenCol: [],
            headingRow: true,
            searchField: [],
            searchMatch: 'begin',
            valueField: [],
            valueSeperator: ' ',
            HTMLSelect: false,
            selectMultiple: false,
            closeOnEsc: false,
            placeholder: 'Enter Name',
            noRecord: 'No record has found'
        }, options);

        var win_w = $(window).width();
        var $this = $(this); $this.val('').attr('placeholder', settings.placeholder);
        var tbl_w = ((settings.width > win_w) ? win_w - 15 : settings.width);
        var maxHeight = ((settings.maxHeight > $(window).height()) ? $(window).height() : settings.maxHeight);
        var divleft = $this.position().left;
        if ((tbl_w + divleft) > win_w)
            divleft =  (win_w - tbl_w) / 2;
        var divtop = $this.position().top + $this.outerHeight();
        if ((maxHeight + divtop) > $(window).height())
            maxHeight = $(window).height() - divtop - 5;
        else maxHeight -= 10;
        if (maxHeight < 80) maxHeight = 80;
        var timr;
        var key, textval, rownum, ttable, tbody, selected, selectedIndex;
        var scrHeight;
        var tScrHeight, scrTop = 0, trHeight, tTrHeight;
        var selected_id, selected_ids, selected_text, selected_html;
        var CBTautocomplete = {
            getID: function () { return selected_id; },
            getIDs: function () { return selected_ids; },
            getText: function () { return selected_text; },
            getRow: function (elm) {
                if (elm != "" && elm != null) return selected_html.replace(/td>/g, elm + '>');
                else return selected_html;
            }
        };
        try { $('#rd_' + $this.attr('id')).remove(); } catch (ee) { }
        var table_data = "<table class='ift_table' width='" + (tbl_w - 18) + "px' cellspacing='0' cellpadding='0'>";
        table_data += "<caption>" + settings.noRecord + "</caption>";
        table_data += "<thead><tr class='heading'>";
        for (c in settings.column)
            table_data += "<th>" + settings.column[c] + "</th>";
        table_data += "</tr></thead><tbody>";
        $.each(settings.data, function (i, jsobj) {
            key = 0; table_data += "<tr class='" + ((i % 2 == 0) ? 'even' : 'odd') + "'";
            for (f in jsobj) {
                if (f == "id") table_data += " data-id='" + jsobj[f] + "'>";
                else table_data += "<td" + ((settings.HTMLSelect == true && key == 1) ? ((settings.selectMultiple == true) ? " class='first_selectm'" : " class='first'") : "") + ">" + jsobj[f] + "</td>";
                key++;
            } table_data += "</tr>";
        }); table_data += "</tbody>";
        var rootdv = "<div class='ift_rootdiv' id='rd_" + $this.attr('id') + "' style='width:" + tbl_w + "px;max-height:" + maxHeight + "px;top:" + divtop + "px;left:" + divleft + "px;'>" + table_data + "</div>";
        $('body').append(rootdv);
        ttable = $('#rd_' + $this.attr('id') + ' .ift_table');
        tbody = ttable.find("tbody");
        if (settings.headingRow == false)
            $('.ift_table tr.heading').removeClass('visible').addClass('hidden');
        if (win_w <= 320) {
            for (var i = settings.xsHiddenCol.length - 1; i >= 0; i--) {
                key = parseInt(settings.xsHiddenCol[i], 10) - 1;
                ttable.find('thead tr').each(function (i, e) {
                    $(e).find('th').eq(key).remove();
                });
                tbody.find('tr').each(function (i, e) {
                    $(e).find('td').eq(key).remove();
                });
            }
        }
        else if (win_w <= 480) {
            for (var i = settings.sHiddenCol.length - 1; i >= 0; i--) {
                key = parseInt(settings.sHiddenCol[i], 10) - 1;
                ttable.find('thead tr').each(function (i, e) {
                    $(e).find('th').eq(key).remove();
                });
                tbody.find('tr').each(function (i, e) {
                    $(e).find('td').eq(key).remove();
                });
            }
        }
        else if (win_w <= 640) {
            for (var i = settings.mHiddenCol.length - 1; i >= 0; i--) {
                key = parseInt(settings.mHiddenCol[i], 10) - 1;
                ttable.find('thead tr').each(function (i, e) {
                    $(e).find('th').eq(key).remove();
                });
                tbody.find('tr').each(function (i, e) {
                    $(e).find('td').eq(key).remove();
                });
            }
        }
        else {
            for (var i = settings.lHiddenCol.length - 1; i >= 0; i--) {
                key = parseInt(settings.lHiddenCol[i], 10) - 1;
                ttable.find('thead tr').each(function (i, e) {
                    $(e).find('th').eq(key).remove();
                });
                tbody.find('tr').each(function (i, e) {
                    $(e).find('td').eq(key).remove();
                });
            }
        }

        if (settings.HTMLSelect == true) {

            $this.focus(function (e) {
                divleft = $this.position().left;
                if ((tbl_w + divleft) > win_w)
                    divleft = (win_w - tbl_w) / 2;
                divtop = $this.position().top + $this.outerHeight();
                $('#rd_' + $this.attr('id')).css({ 'top': divtop, 'left': divleft });
                scrTop = 0;
                tbody.find('tr').removeClass('visible odd even active').addClass('hidden');
                ttable.find('caption').removeClass('visible').addClass('hidden');
                if (settings.headingRow == true)
                    ttable.find('tr.heading').removeClass('visible hidden');
                ttable.slideDown('slow');
                rownum = 0;
                tbody.find('tr').each(function (i, e) {
                    if ($this.val() != "") {
                        for (i in settings.searchField) {
                            try {
                                key = parseInt(settings.searchField[i], 10) - 1;
                                console.log(key);
                                if (settings.searchMatch == "begin" && $(e).find('td').eq(key).text().toLowerCase().indexOf($this.val().toLowerCase()) == 0) {
                                    $(e).removeClass('hidden').addClass('visible');
                                }
                                else if (settings.searchMatch == "any" && $(e).find('td').eq(key).text().toLowerCase().indexOf($this.val().toLowerCase()) >= 0) {
                                    $(e).removeClass('hidden').addClass('visible');
                                }

                                tbody.find('tr.visible').each(function (i, e) {
                                    $(e).addClass(((i % 2 == 0) ? 'even' : 'odd'));
                                });
                            } catch (ee) { }
                        }//for
                    }//if
                    else {
                        tbody.find('tr').removeClass('hidden').addClass('visible');
                        tbody.find('tr').each(function (i, e) {
                            $(e).addClass(((i % 2 == 0) ? 'even' : 'odd'));
                        });
                    }
                });
                if (tbody.find(".visible").length == 0) {
                    ttable.find('tr.heading').addClass('hidden');
                    ttable.find('caption').removeClass('hidden').addClass('visible');
                }
                tScrHeight = $('.ift_rootdiv')[0].scrollHeight;
            });//focus
        }
        $this.keyup(function (e) {
            key = (e.which) ? e.which : e.keyCode;
            if (key == 27) {
                if (settings.closeOnEsc == true)
                    ttable.fadeOut(100);
                return;
            }
            if (key == 13) {
                if (settings.selectMultiple == false)
                    tbody.find(".selected").removeClass("selected");
                tbody.find(".active").removeClass("active").addClass("selected");
                add_select();
                return;

            }
            if (key == 40) {
                try { clearTimeout(timr); } catch (ee) { }
                selectedIndex = -1;
                tbody.find('tr.visible').each(function (i, e) {
                    if ($(e).hasClass('active'))
                        selectedIndex = i;
                });

                if (selectedIndex == -1 || (selectedIndex >= (tbody.find(".visible").length - 1))) selectedIndex = 0;
                else selectedIndex++;
                tTrHeight = tbody.find("tr.visible").eq(selectedIndex).position().top;
                trHeight = tbody.find("tr.visible").eq(selectedIndex).height();
                if ((maxHeight - (trHeight * 2)) > tTrHeight)
                    scrTop = 0;
                else scrTop = tTrHeight + scrTop - maxHeight + 30 + trHeight;
                if (scrTop < 0) scrTop = 0;
                $('#rd_' + $this.attr('id')).scrollTop(scrTop);
                tbody.find(".active").removeClass("active");
                tbody.find("tr.visible").eq(selectedIndex).addClass("active");
                e.preventDefault();
                if (settings.selectMultiple == true)
                    timr = setTimeout(function () { ttable.fadeOut(100); }, 6000);
                return;
            }
            if (key == 38) {
                try { clearTimeout(timr); } catch (ee) { }
                selectedIndex = -1;
                tbody.find('tr.visible').each(function (i, e) {
                    if ($(e).hasClass('active'))
                        selectedIndex = i;
                });
                if (selectedIndex == -1) selectedIndex = tbody.find(".visible").length - 1;
                else selectedIndex--;
                tbody.find(".active").removeClass("active");
                if (selectedIndex == -1)
                    selectedIndex = tbody.find(".visible").length - 1;
                tbody.find("tr.visible").eq(selectedIndex).addClass("active");
                tTrHeight = tbody.find("tr.visible").eq(selectedIndex).position().top;
                trHeight = tbody.find("tr.visible").eq(selectedIndex).height();
                if ((maxHeight - (trHeight * 2)) < tTrHeight)
                    scrTop = tScrHeight;
                else scrTop = tTrHeight + scrTop - maxHeight + 30 + trHeight;
                if (scrTop < 0) scrTop = 0;
                $('#rd_' + $this.attr('id')).scrollTop(scrTop);
                e.preventDefault();
                if (settings.selectMultiple == true)
                    timr = setTimeout(function () { ttable.fadeOut(100); }, 6000);
                return;
            }
            if ((key < 46 || key > 90) && (key != 8)) {
                e.preventDefault();
                return;
            }

            //new
            divleft = $this.position().left;
            if ((tbl_w + divleft) > win_w)
                divleft = (win_w - tbl_w) / 2;
            divtop = $this.position().top + $this.outerHeight();
            $('#rd_' + $this.attr('id')).css({ 'top': divtop, 'left': divleft });
            scrTop = 0;
            tbody.find('tr').removeClass('visible odd even active').addClass('hidden');
            ttable.find('caption').removeClass('visible').addClass('hidden');
            if (settings.headingRow == true)
                ttable.find('tr.heading').removeClass('visible hidden');
            ttable.slideDown('slow');
            rownum = 0;
            tbody.find('tr').each(function (i, e) {
                if ($this.val() != "") {
                    for (i in settings.searchField) {
                        try {
                            key = parseInt(settings.searchField[i], 10) - 1;
                            if (settings.searchMatch == "begin" && $(e).find('td').eq(key).text().toLowerCase().indexOf($this.val().toLowerCase()) == 0) {
                                $(e).removeClass('hidden').addClass('visible');
                            }
                            else if (settings.searchMatch == "any" && $(e).find('td').eq(key).text().toLowerCase().indexOf($this.val().toLowerCase()) >= 0) {
                                $(e).removeClass('hidden').addClass('visible');
                            }

                            tbody.find('tr.visible').each(function (i, e) {
                                $(e).addClass(((i % 2 == 0) ? 'even' : 'odd'));
                            });
                        } catch (ee) { }
                    }//for
                }//if
                else {
                    tbody.find('tr').removeClass('hidden').addClass('visible');
                    tbody.find('tr').each(function (i, e) {
                        $(e).addClass(((i % 2 == 0) ? 'even' : 'odd'));
                    });
                }
            });

            if (tbody.find(".visible").length == 0) {
                ttable.find('tr.heading').addClass('hidden');
                ttable.find('caption').removeClass('hidden').addClass('visible');
            }

            tScrHeight = $('.ift_rootdiv')[0].scrollHeight;
        });//keyup

        tbody.delegate("tr", "mousedown", function () {

            if (settings.selectMultiple == false)
                tbody.find('tr').removeClass('selected');// selected visible odd
            console.log($(this).context.className);
            //   if ($(this).context.className === "selected visible even" || $(this).context.className === "selected  visible odd") {
            if ($(this).context.className === "visible even selected" || $(this).context.className === "visible odd selected" || $(this).context.className === "selected visible even" || $(this).context.className === "selected  visible odd") {

                console.log('CLICK unselected');
                $(this).removeClass("selected");
            }
            else {
                console.log('CLICK selected');
                $(this).addClass("selected");
            }
            //$(this).addClass("selected");
            add_select();
        });
        ttable.hover(function () {
        }, function () {
            if (settings.selectMultiple == true)
                timr = setTimeout(function () { ttable.fadeOut(100); }, 2000);
        });

        $this.blur(function () {
            if (settings.HTMLSelect == true && settings.selectMultiple == true) {
            }
            else ttable.fadeOut(1000);
        });
        function add_select() {
            selected = tbody.find('tr.selected');

            selected_id = selected.data('id');
            selected_html = selected.html();
            selected_html = selected_html.replace(" class='first'", "");
            selected_html = selected_html.replace(' class="first"', '');
            selected_html = selected_html.replace(" class='first_selectm'", "");
            selected_html = selected_html.replace(' class="first_selectm"', '');

            selected_ids = "";
            if (settings.HTMLSelect == true && settings.selectMultiple == true) {
                tbody.find('tr.selected').each(function (i, e) {
                    selected_ids += ((selected_ids != "") ? "," : "") + $(e).data('id');
                });
            }
            selected_text = '';
            for (i in settings.valueField) {
                if (selected_text != '')
                    selected_text += settings.valueSeperator;
                try {
                    key = parseInt(settings.valueField[i], 10) - 1;
                    selected_text += selected.find('td').eq(key).text();
                } catch (ee) { }
            }//for

            if (settings.HTMLSelect == true && settings.selectMultiple == true) {
                $this.val(selected_text);
                $this.attr('data-id', selected_ids);
            }
            else {
                $this.val(selected_text).focus();
                $this.attr('data-id', selected_id);

                ttable.fadeOut(500);
            }
        }

        return CBTautocomplete;

    };

}(jQuery));