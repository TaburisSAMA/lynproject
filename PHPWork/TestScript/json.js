dfbg = "#555555";
widgetParams = new Object();
donePreInit = false;
document.ondragstart = function() {
	return false
};
if (typeof console == "undefined") {
	console = new Object();
	console.log = function() {
	}
}
window.addEvent("domready", function() {
	if (!donePreInit) {
		initInt = preInit()
	}
});
function preInit() {
	if (typeof App == "undefined") {
		return
	}
	schmedley = new App(registerOnly, inviteOnly);
	window.alert = schmedley.alert.bindWithEvent(schmedley);
	window.addEvent("resize", schmedley.adjustLayout);
	var A = $(document.body);
	A.setStyle("background-color", dfbg);
	donePreInit = true
}
function warning(C, B, A) {
	new Warning(C, B, A)
}
window.addEvent("load", function() {
	if (!donePreInit) {
		preInit()
	}
	schmedley.postInit()
});
function gls(B) {
	try {
		return ls[B]
	} catch (A) {
	}
	return B
}
function toggleGradient(B) {
	var A = schmedley.getActiveDesk();
	if (!A) {
		return
	}
	A.toggleGradient(B);
	schmedley.updateColors()
};
var Alert = new Class( {
	Extends :Object,
	initialize : function(I, B, F) {
		var D = window.getWidth();
		var E = window.getHeight();
		var G = 350;
		var A = 200;
		var C = Math.floor((D - G) / 2);
		var H = Math.floor((E - A) / 2);
		this.el = new Element("div", {
			"class" :"alert"
		});
		this.el.setStyles( {
			top :H,
			opacity :0
		}).injectInside(document.body);
		this.alertTxt = new Element("div", {
			"class" :"alertText",
			html :I + "\n"
		}).injectInside(this.el);
		if (!F || F == "") {
			F = "OK"
		}
		this.alertOK = new Button("i", this.el, "alertOK", "b", 156, 138, F,
				this.cancel.bindWithEvent(this), "");
		this.onOK = B;
		schmedley.fade("in", this.el)
	},
	cancel : function() {
		if (this.onOK) {
			this.onOK.call()
		}
		this.el.destroy();
		schmedley.blackOut("out")
	}
});
var Warning = new Class(
		{
			Extends :Object,
			initialize : function(I, F, A) {
				var C = window.getWidth();
				var D = window.getHeight();
				var H = 520;
				var E = 310;
				var B = Math.floor((C - H) / 2);
				var G = Math.floor((D - E) / 2);
				this.el = new Element("div", {
					"class" :"warning"
				});
				this.el.setStyles( {
					top :G,
					opacity :0,
					"z-index" :105
				}).injectInside(document.body);
				this.warningTxt = new Element("div", {
					"class" :"warningText",
					html :I + "\n"
				}).injectInside(this.el);
				this.alertOK = new Button("i", this.el, "warningOK", "b", 0,
						225, F, this.cancel.bindWithEvent(this), "");
				$("warningOK").setStyle("left",
						(520 - $("warningOK").clientWidth) / 2);
				this.onOK = A;
				schmedley.fade("in", this.el)
			},
			cancel : function() {
				if (this.onOK) {
					this.onOK.call()
				}
				this.el.destroy();
				schmedley.blackOut("out")
			}
		});
var App = new Class(
		{
			initialize : function(C, F) {
				this.registerOnly = C;
				this.inviteOnly = F;
				this.activeDesktopID;
				this.tabs = new Object();
				this.desktops = new Object();
				this.widgets = new Object();
				this.widgetParams = new Object();
				this.isLoggedIn = false;
				this.launchers = new Object();
				this.cookieName = "schmedleyData";
				this.cookieData = JSON.decode(Cookie.read(this.cookieName));
				var D = /https{0,1}:\/\/([^\/]+)(.*)$/;
				var E = D.exec(location.href);
				this.domain = E[1];
				this.baseURL = this.domain + E[2];
				this.widgetsCount = 0;
				if (Browser.Engine.trident5) {
					this.useFade = false
				} else {
					this.useFade = true
				}
				var A = this;
				var B = new Element("div", {
					"class" :"butb signup",
					id :"signup"
				});
				B
						.set(
								"html",
								'<div class="butl"></div><div class="butc">' + gls("but7") + '</div><div class="butr"></div>');
				B.inject($("infobox"));
				B.setStyles( {
					position :"absolute",
					top :"14px",
					left :"35px",
					height :"25px",
					display :"block",
					overflow :"hidden"
				});
				B.addEvent("mousedown", function(G) {
					G = new Event(G).stop();
					this.setProperty("class", "bdown")
				}).addEvent("mouseup", function(G) {
					G = new Event(G).stop();
					this.setProperty("class", "butb signup")
				}).addEvent("click", function(G) {
					G = new Event(G).stop();
					A.launchSignup()
				});
				$("signin").set("html", gls("but8"));
				this.bo = new Element("div", {
					"class" :"blackout"
				});
				this.bos = new Element("div", {
					"class" :"blackoutSemi",
					opacity :0.9
				});
				this.bos.set("html", "&nbsp;");
				this.bos.injectInside(this.bo);
				this.bo.injectInside(document.body);
				this.colorLaunch = $("color");
				this.colorLaunch.addEvent("click", this.manageColor
						.bindWithEvent(this))
			},
			run : function() {
				var A = $("signin");
				if (A) {
					this.shimmyLogin(A);
					A.removeEvents("click");
					A.addEvent("click", this.launchLogin.bindWithEvent(this))
				}
				if (this.registerOnly) {
					this.launchSignup()
				} else {
					wf = new WidgetFactory();
					lf = new LauncherFactory();
					this.verifyLogin()
				}
			},
			activate : function() {
				var C = $("flag");
				if (C) {
					C.removeEvents("click");
					C.addEvent("click", function(I) {
						alert("international support is coming soon...")
					})
				}
				var G = $("info");
				if (G) {
					G.removeEvents("click");
					G.addEvent("click", this.schmedleyInfo.bindWithEvent(this))
				}
				var H = $("home");
				if (H) {
					H.removeEvents("click");
					H.addEvent("click", this.homeInstructions
							.bindWithEvent(this))
				}
				var E = $("copy");
				E.removeEvents("click");
				E.addEvent("click", this.copyrightLink.bindWithEvent(this));
				var D = $("grad1");
				D.removeEvents("click");
				D.addEvent("click", function(I) {
					I = new Event(I).stop();
					toggleGradient(1)
				});
				var B = $("grad2");
				B.removeEvents("click");
				B.addEvent("click", function(I) {
					I = new Event(I).stop();
					toggleGradient(2)
				});
				var A = $("dsktp");
				if (A) {
					A.removeEvents("click");
					A.addEvent("click", this.desktopPics.bindWithEvent(this))
				}
				var F = $("buggy");
				F.removeEvents("click");
				F.addEvent("click", this.bugReport.bindWithEvent(this));
				this.bugreport = F;
				this.attachDockEvents();
				this.attachTabEvents()
			},
			desktopPics : function() {
				if ($("BGpicker")) {
				} else {
					function I() {
						( function() {
							var M = $$("a.bglabel");
							var L = $$("div.bggrid");
							M.each( function(N) {
								N.removeClass("actvlabel")
							});
							L.each( function(N) {
								N.setStyle("display", "none")
							});
							$(schmedley.bgpage).setStyle("display", "block");
							$(schmedley.bgpage + "Label").addClass("actvlabel")
						}).delay(100)
					}
					if (!schmedley.bgpage) {
						schmedley.bgpage = "plasma"
					}
					var D = new Element("div", {
						id :"plasma",
						"class" :"bggrid"
					});
					var G = new Element("div", {
						id :"dryico",
						"class" :"bggrid"
					});
					var A = new Element("div", {
						id :"kramer",
						"class" :"bggrid"
					});
					var C = new Element("div", {
						id :"windoz",
						"class" :"bggrid"
					});
					var K = new Element("div", {
						id :"papers",
						"class" :"bggrid"
					});
					var B = new Element("div", {
						id :"BGpicker"
					})
							.adopt(new Element("h1", {
								html :"desktop backgrounds"
							}))
							.adopt(
									new Element("div")
											.setStyles( {
												position :"absolute",
												right :"24px",
												top :"24px"
											})
											.adopt(
													new Element(
															"div",
															{
																"class" :"butb",
																html :'<div class="butl"></div><div class="butc">Remove Current Background</div><div class="butr"></div>'
															})
															.addEvent(
																	"click",
																	function() {
																		var L = J
																				.getActiveDesk();
																		if (L) {
																			L
																					.setBGImage("")
																		}
																	}))).adopt(
									new Element("a", {
										href :"#",
										id :"plasmaLabel",
										"class" :"bglabel",
										html :"Plasma Design"
									}).addEvent("click", function() {
										schmedley.bgpage = "plasma";
										I();
										return false
									})).adopt(new Element("a", {
								href :"#",
								id :"dryicoLabel",
								"class" :"bglabel",
								html :"DryIcons"
							}).addEvent("click", function() {
								schmedley.bgpage = "dryico";
								I();
								return false
							})).adopt(new Element("a", {
								href :"#",
								id :"kramerLabel",
								"class" :"bglabel",
								html :"Robb Kramer"
							}).addEvent("click", function() {
								schmedley.bgpage = "kramer";
								I();
								return false
							})).adopt(new Element("a", {
								href :"#",
								id :"windozLabel",
								"class" :"bglabel",
								html :"Vista-esque"
							}).addEvent("click", function() {
								schmedley.bgpage = "windoz";
								I();
								return false
							})).adopt(new Element("a", {
								href :"#",
								id :"papersLabel",
								"class" :"bglabel",
								html :"wallpaper"
							}).addEvent("click", function() {
								schmedley.bgpage = "papers";
								I();
								return false
							})).adopt(D).adopt(G).adopt(A).adopt(C).adopt(K);
					B.inject($("ColourMod"), "after");
					B.setOpacity(1);
					schmedley.addDialogClose(B);
					schmedley.fade("in", B);
					B.makeDraggable();
					I()
				}
				var H = '<div class="bgthumb"><img src="css/img/bg/desktops/default.htm';
				var F = '</div><div class="bgthumb"><img src="css/img/bg/desktops/default.htm';
				var E = '</div><div class="wpthumb"><img src="css/img/bg/wp/default.htm';
				D
						.set(
								"html",
								H
										+ 'http://schmedley.com/js/plasma01t.jpg" /><br />Aqua'
										+ F
										+ 'plasma02t.jpg" /><br />Going Up'
										+ F
										+ 'http://schmedley.com/js/plasma03t.jpg" /><br />Dewdrop (detail)'
										+ F
										+ 'plasma04t.jpg" /><br />Velvet'
										+ F
										+ 'http://schmedley.com/js/plasma05t.jpg" /><br />Stamen'
										+ F
										+ 'plasma06t.jpg" /><br />Radial'
										+ F
										+ 'http://schmedley.com/js/plasma07t.jpg" /><br />Photosynthesis'
										+ F
										+ 'plasma08t.jpg" /><br />Marine'
										+ F
										+ 'http://schmedley.com/js/plasma09t.jpg" /><br />Torrent'
										+ F
										+ 'plasma10t.jpg" /><br />Spark</div><div class="bgcredits"><a href="http://plasmadesign.co.uk/" target="_new">http:http://plasmadesign.co.uk/</a></div>');
				G
						.set(
								"html",
								H
										+ 'dryico01t.jpg" /><br />Pink Clouds'
										+ F
										+ 'http://schmedley.com/js/dryico02t.jpg" /><br />Snow'
										+ F
										+ 'dryico03t.jpg" /><br />Wild Nature'
										+ F
										+ 'http://schmedley.com/js/dryico04t.jpg" /><br />Fall In Love'
										+ F
										+ 'dryico05t.jpg" /><br />Spring Flowers'
										+ F
										+ 'http://schmedley.com/js/dryico06t.jpg" /><br />Spring Banner'
										+ F
										+ 'dryico07t.jpg" /><br />Rainy Window'
										+ F
										+ 'http://schmedley.com/js/dryico08t.jpg" /><br />Best Friends'
										+ F
										+ 'dryico09t.jpg" /><br />Abstract Girl'
										+ F
										+ 'http://schmedley.com/js/dryico10t.jpg" /><br />Shower</div><div class="bgcredits"><a href="http://dryicons.com/" target="_new">http:http://dryicons.com/</a></div>');
				A
						.set(
								"html",
								H
										+ 'kramer01t.jpg" /><br />Contraflow'
										+ F
										+ 'http://schmedley.com/js/kramer02t.jpg" /><br />Electric Stream'
										+ F
										+ 'kramer03t.jpg" /><br />October Strings'
										+ F
										+ 'http://schmedley.com/js/kramer04t.jpg" /><br />Fortress'
										+ F
										+ 'kramer05t.jpg" /><br />Northrup Ice'
										+ F
										+ 'http://schmedley.com/js/kramer06t.jpg" /><br />Enhance'
										+ F
										+ 'kramer07t.jpg" /><br />Amuse'
										+ F
										+ 'http://schmedley.com/js/kramer08t.jpg" /><br />Nightwatch'
										+ F
										+ 'kramer09t.jpg" /><br />Deep'
										+ F
										+ 'http://schmedley.com/js/kramer10t.jpg" /><br />Garden</div><div class="bgcredits"><a href="http://robbkramer.com/" target="_new">http:http://robbkramer.com/</a></div>');
				C
						.set(
								"html",
								H
										+ 'windoz01t.jpg" /><br />Bliss'
										+ F
										+ 'http://schmedley.com/js/windoz02t.jpg" /><br />Plane'
										+ F
										+ 'windoz03t.jpg" /><br />Rose Aura'
										+ F
										+ 'http://schmedley.com/js/windoz04t.jpg" /><br />Warm Aura'
										+ F
										+ 'windoz05t.jpg" /><br />Striped Aura'
										+ F
										+ 'http://schmedley.com/js/windoz06t.jpg" /><br />Blue'
										+ F
										+ 'windoz07t.jpg" /><br />Indigo'
										+ F
										+ 'http://schmedley.com/js/windoz08t.jpg" /><br />White'
										+ F
										+ 'windoz09t.jpg" /><br />Orange'
										+ F
										+ 'http://schmedley.com/js/windoz10t.jpg" /><br />Green</div>');
				K
						.set(
								"html",
								'<div class="wpthumb"><img src="css/img/bg/wp/01t.jpg" /><br />1'
										+ E
										+ '02t.jpg" /><br />2'
										+ E
										+ 'http://schmedley.com/js/03t.jpg" /><br />3'
										+ E
										+ '04t.jpg" /><br />4'
										+ E
										+ 'http://schmedley.com/js/05t.jpg" /><br />5'
										+ E
										+ '06t.jpg" /><br />6'
										+ E
										+ 'http://schmedley.com/js/07t.jpg" /><br />7'
										+ E
										+ '08t.jpg" /><br />8'
										+ E
										+ 'http://schmedley.com/js/09t.jpg" /><br />9'
										+ E
										+ '10t.jpg" /><br />10'
										+ E
										+ 'http://schmedley.com/js/11t.jpg" /><br />11'
										+ E
										+ '12t.jpg" /><br />12'
										+ E
										+ 'http://schmedley.com/js/13t.jpg" /><br />13'
										+ E
										+ '14t.jpg" /><br />14'
										+ E
										+ 'http://schmedley.com/js/15t.jpg" /><br />15'
										+ E
										+ '16t.jpg" /><br />16'
										+ E
										+ 'http://schmedley.com/js/17t.jpg" /><br />17'
										+ E
										+ '18t.jpg" /><br />18'
										+ E
										+ 'http://schmedley.com/js/19t.jpg" /><br />19'
										+ E
										+ '20t.jpg" /><br />20'
										+ E
										+ 'http://schmedley.com/js/21t.jpg" /><br />21'
										+ E
										+ '22t.jpg" /><br />22'
										+ E
										+ 'http://schmedley.com/js/23t.jpg" /><br />23'
										+ E
										+ '24t.jpg" /><br />24'
										+ E
										+ 'http://schmedley.com/js/25t.jpg" /><br />25'
										+ E
										+ '26t.jpg" /><br />26'
										+ E
										+ 'http://schmedley.com/js/27t.jpg" /><br />27</div>');
				var J = this;
				( function() {
					var L = $$("div.bgthumb", "div.wpthumb");
					L.each( function(M) {
						M.addEvent("click", function(O) {
							O = new Event(O).stop();
							var P = M.getFirst().src.toString();
							var N = J.getActiveDesk();
							if (N) {
								N.setBGImage(P)
							}
						})
					})
				}).delay(200)
			},
			schmedleyInfo : function() {
				if ($("infoDialog")) {
				} else {
					var A = new Element("div", {
						id :"infoDialog"
					});
					A
							.set(
									"html",
									'<a style="font-size: 17px;" href="http://blog.schmedley.com/" target="_new">blog<span style="margin-left: 4px; margin-right: 3px;">/</span>news</a>&nbsp;&nbsp; <a style="font-size: 14px;" href="http://blog.schmedley.com/vote/" target="_new">polls<span style="margin-left: 4px; margin-right: 3px;">/</span>surveys</a>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <a style="font-size: 14px;" href="http://help.schmedley.com/" target="_new">help<span style="margin-left: 4px; margin-right: 3px;">/</span>support</a>&nbsp;&nbsp; <a style="font-size: 11px;" href="http://help.schmedley.com/discussions" target="_new">forums<span style="margin-left: 4px; margin-right: 3px;">/</span>discussion</a>&nbsp;&nbsp; <a href="http://help.schmedley.com/faqs" target="_new">FAQs<span style="margin-left: 4px; margin-right: 3px;">/&nbsp;</span> <span style="font-size: 12px;">knowledge&nbsp;base</span></a>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <a href="http://blog.schmedley.com/about/" target="_new">about</a>&nbsp;&nbsp; <a href="http://blog.schmedley.com/contact/" target="_new">contact</a>&nbsp;&nbsp; <a href="http://blog.schmedley.com/team/" target="_new">team</a>&nbsp;&nbsp; <a href="http://blog.schmedley.com/partners/" target="_new">partners</a>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a style="font-size: 11px;" href="http://blog.schmedley.com/about/privacy-policy/" target="_new">privacy policy</a><br /><a style="font-size: 11px;" href="http://blog.schmedley.com/about/terms-of-use/" target="_new">terms of use</a>');
					A.inject($("rite"));
					A.setOpacity(0);
					schmedley.addDialogClose(A);
					schmedley.fade("in", A);
					( function() {
						schmedley.fade("out", A)
					}).delay(20000);
					( function() {
						$("infoDialog").destroy()
					}).delay(21000)
				}
			},
			copyrightLink : function() {
				window.open("http://blog.schmedley.com/about/", "", "")
			},
			homeInstructions : function() {
				var A = this;
				var B;
				if (Browser.Engine.trident == true) {
					document.body.style.behavior = "url(#default#homepage)";
					document.body.setHomePage("http://www.schmedley.com/")
				} else {
					if (Browser.Engine.gecko == true) {
						B = "Firefox"
					} else {
						if (Browser.Engine.webkit == true) {
							B = "Safari"
						} else {
						}
					}
					new Confirm(
							gls("acp5") + " " + B + ".<br />" + gls("acp6"),
							function() {
								if (B == "Firefox") {
									window
											.open("http://support.mozilla.com/en-US/kb/How+to+set+the+home+page")
								} else {
									if (B == "Safari") {
										window
												.open("http://helposx.apple.com/leopard/safarihelphelpr1/English.lproj/pgs/9268.html")
									} else {
									}
								}
							})
				}
			},
			postInit : function() {
				this.adjustLayout();
				new Asset.images( [ "css/img/dialog-tab.png",
						"css/img/dialog-log.png", "css/img/dialog-sup.png",
						"css/img/dialog-bug.png", "css/img/dialog-info.png",
						"http://schmedley.com/js/css/img/promptBox350.png" ]);
				var self = this;
				this.dock = new Dock();
				if (!this.registerOnly && (typeof Widget) == "undefined") {
					new Request( {
						url :"http://schmedley.com/js/js/schmedleyMore.js",
						onSuccess : function(response) {
							eval(response);
							self.run()
						}
					}).get()
				} else {
					self.run()
				}
				if ($("signup")) {
					var subw = $("signup").getFirst().getNext().clientWidth + 20;
					$("signup").setStyle("left", ((135 - subw) / 2) + "px")
				}
				var req = new Request( {
					url :"http://schmedley.com/js/ads.php",
					onSuccess : function(text, xml) {
						var adSpace = $("adSpace");
						if (adSpace) {
							adSpace.innerHTML = text;
							self.adjustLayout.delay(1000, self)
						}
					}
				});
				req.get()
			},
			registerInDock : function(A) {
				var B = new Element("img", {
					id :A,
					src :"css/img/dock/" + A + ".png",
					alt :upperFirst(A)
				});
				B.inject("dock")
			},
			addDesktop : function(F, A) {
				var I = A.name;
				var Q = A.bgcolor;
				var P = A.bgimage;
				var J = A.gradient;
				var D = A.active;
				var M = A.isWidgetTab;
				var E = A.privacy;
				var C = A.tabURLName;
				var L = A.defaultTab;
				var O = A.indexTab;
				var K;
				if (Q && Q != "") {
					K = Q
				} else {
					K = dfbg
				}
				if (M == 1) {
					var N = new Desktop(F, this, "", "", J);
					switch (I) {
					case "meebo":
						N.el
								.setStyles( {
									"background-image" :"url(http://schmedley.com/js/apps/meebo/img/meebo-bg.png)",
									"background-position" :"0px 0px",
									"background-repeat" :"repeat-x"
								});
						var H = new Element("iframe", {
							id :"schmeebo",
							src :"https://www.meebo.com/",
							scrolling :"auto",
							frameborder :0
						});
						H.injectInside(N.el);
						var B = new Element(
								"div",
								{
									style :"position: absolute; top: 97px; left: 19px; width: 1px; height: 3px; background: #7094c8;"
								});
						B.injectInside(N.el)
					}
				} else {
					var N = new Desktop(F, this, K, P, J)
				}
				this.desktops[F] = N;
				var G = new Tab(I, N, M, E, C, L);
				G.indexTab = O;
				this.tabs[F] = G;
				if (D == 1) {
					this.selectTab(G, true)
				}
				return N
			},
			attachTabEvents : function() {
				var B = $("tabAdd");
				B.removeEvents("click");
				var A = this;
				B.addEvent("click", function() {
					A.newTab(true, "", 0)
				})
			},
			attachDockEvents : function() {
				$$("#dock img").each(
						function(B, A, C) {
							B.removeEvents("click");
							if (B.className == "widgetTab") {
								B.addEvent("click", this.confirmWidgetTab
										.bindWithEvent(this))
							} else {
								if (B.className == "launcher") {
									B.addEvent("click",
											this.widgetLauncherClick
													.bindWithEvent(this))
								} else {
									B.addEvent("click", this.widgetIconClick
											.bindWithEvent(this))
								}
							}
						}, this)
			},
			removeDockEvents : function() {
				$$("#dock img").each( function(B, A, C) {
					B.removeEvents("click")
				}, this)
			},
			widgetIconClick : function(A) {
				this.newWidget(A.target.id)
			},
			newWidget : function(A, B) {
				if (!this.isWidgetLoaded(A)) {
					this.widgetLoad(A, B)
				} else {
					this.createWidget(A, B)
				}
			},
			widgetLauncherClick : function(A) {
				widgetName = A.target.id;
				if (!this.isWidgetLoaded(widgetName)) {
					this.launcherLoad(widgetName)
				} else {
					this.createLauncher(widgetName)
				}
			},
			confirmWidgetTab : function(B) {
				widgetName = B.target.id;
				var A = this;
				new Confirm(widgetName
						+ " will be launched in its own tab.  Is that OK?",
						function() {
							A.widgetTabClick(widgetName)
						})
			},
			widgetTabClick : function(A) {
				this.newTab(false, A, 1)
			},
			selectTab : function(C) {
				var A = C.desk;
				for ( var B in this.tabs) {
					var D = this.tabs[B];
					D.active(false)
				}
				C.active(true);
				if ($("cmDefault")) {
					closeColor()
				}
				this.activeDesktopID = C.dbID;
				this.updateColors();
				if (C.isWidgetTab == 1) {
					this.dock.hide();
					$$("#color, #grad1, #grad2", "#dsktp", "#toolbar")
							.setStyle("display", "none")
				} else {
					this.dock.show();
					$$("#color, #grad1, #grad2", "#dsktp", "#toolbar")
							.setStyle("display", "block")
				}
				this.setPrivacyStyles(C.privacy, true)
			},
			setPrivacyStyles : function(U, M) {
				var G = $("logo");
				var O = $("logoImg");
				var I = $("logoEnv");
				var T = $("tabs");
				var S = G.getStyle("left");
				var N = T.getStyle("left");
				if (U == "public") {
					var P = window.getSize();
					var R = 151;
					var Q = 65;
					var C = P.x - R - 9;
					var B = 3;
					var J = 20;
					var F = 15;
					var E = 61;
					var K = "center"
				} else {
					var C = 0;
					var B = 0;
					var J = 230;
					var R = 210;
					var Q = 90;
					var F = 175;
					var E = 75;
					var K = "left"
				}
				if (M) {
					var D = new Fx.Morph(G);
					var H = new Fx.Morph(O);
					var L = new Fx.Morph(T);
					var A = new Fx.Morph(I);
					L.start( {
						left :J + "px"
					}).chain( function() {
						D.start( {
							left :C,
							top :B
						}).chain( function() {
							H.start( {
								width :R + "px",
								height :Q + "px"
							}).chain( function() {
								D.start( {
									width :R + "px",
									height :Q + "px"
								})
							})
						})
					});
					A.start( {
						left :F + "px",
						top :E + "px",
						"text-align" :K
					})
				} else {
					G.setStyles( {
						left :C,
						top :B
					});
					T.setStyles( {
						left :J
					})
				}
			},
			createWidget : function(E, D) {
				var C = this;
				var B = this.desktops[this.activeDesktopID];
				var I = B.getOpenPosition(E);
				var J = I[0];
				var H = I[1];
				var F = B.widgets.length + 1;
				var A = this.showPending(B, E, J, H, F);
				if (!D) {
					D = new Object()
				}
				D.x = J + "px";
				D.y = H + "px";
				D.z = F;
				var G = new Request.JSON( {
					url :"http://schmedley.com/js/addSchmidget.php",
					async :true,
					onComplete : function(K) {
						if (K.status == "success") {
							var L = K.data.tabWidgetID;
							C.widgetParams[L] = D;
							B.addWidget(E, L, A)
						} else {
							C.alert("Failed to add Schmidget.");
							A.destroy()
						}
					}
				});
				G.send("n=" + E + "&t=" + C.activeDesktopID + "&p="
						+ JSON.encode(D))
			},
			getDimensions : function(A) {
				if (A == "title") {
					return {
						w :160,
						h :80
					}
				}
				if (A == "text") {
					return {
						w :540,
						h :340
					}
				}
				if (A == "photo") {
					return {
						w :320,
						h :400
					}
				}
				if (A == "search") {
					return {
						w :240,
						h :80
					}
				}
				if (A == "images") {
					return {
						w :280,
						h :280
					}
				}
				if (A == "weather") {
					return {
						w :260,
						h :305
					}
				}
				if (A == "showtimes") {
					return {
						w :285,
						h :335
					}
				}
				if (A == "previews") {
					return {
						w :200,
						h :280
					}
				}
				if (A == "asteroids") {
					return {
						w :440,
						h :380
					}
				}
				if (A == "frogger") {
					return {
						w :410,
						h :480
					}
				}
				if (A == "youtube") {
					return {
						w :370,
						h :470
					}
				}
				if (A == "lastfm") {
					return {
						w :220,
						h :220
					}
				}
				if (A == "stocks") {
					return {
						w :250,
						h :125
					}
				}
				if (A == "amazon") {
					return {
						w :240,
						h :125
					}
				}
				if (A == "feed") {
					return {
						w :300,
						h :300
					}
				}
				if (A == "stickyNotes") {
					return {
						w :250,
						h :230
					}
				}
				if (A == "calendar") {
					return {
						w :220,
						h :220
					}
				}
				if (A == "todoList") {
					return {
						w :250,
						h :195
					}
				}
				if (A == "bookmarks") {
					return {
						w :250,
						h :105
					}
				}
				if (A == "facebook") {
					return {
						w :330,
						h :330
					}
				}
				if (A == "myspace") {
					return {
						w :300,
						h :320
					}
				}
				if (A == "twitter") {
					return {
						w :320,
						h :320
					}
				}
				if (A == "contacts") {
					return {
						w :280,
						h :300
					}
				}
				if (A == "gmail") {
					return {
						w :350,
						h :295
					}
				}
				if (A == "yahooMail") {
					return {
						w :350,
						h :295
					}
				}
				if (A == "hotmail") {
					return {
						w :350,
						h :295
					}
				}
				if (A == "mobileMe") {
					return {
						w :350,
						h :295
					}
				}
				if (A == "aolMail") {
					return {
						w :350,
						h :295
					}
				}
				if (A == "genericMail") {
					return {
						w :350,
						h :500
					}
				}
				if (A == "") {
					return {
						w :250,
						h :250
					}
				}
				if (A == "undefined") {
					return {
						w :250,
						h :250
					}
				}
			},
			showPending : function(D, F, B, H, G) {
				var C = this.getDimensions(F).w;
				var E = this.getDimensions(F).h;
				var A = new Element("div", {
					html :"&nbsp;",
					"class" :"pendingWidget"
				});
				A.setStyles( {
					left :(B + 9) + "px",
					top :(H + 4) + "px",
					width :(C - 20) + "px",
					height :(E - 20) + "px",
					"z-index" :G
				});
				A.setOpacity(0);
				A.injectInside(D.el);
				A.set("tween", {
					duration :"short"
				});
				this.fade("in", A);
				return A
			},
			isWidgetLoaded : function(B) {
				var A = document.head.innerHTML.toString();
				return (A.indexOf(B + "JS") >= 0)
			},
			widgetLoad : function(A, B) {
				new Asset.css("apps/" + A + "/" + A + comp + ".css", {
					id :A + "CSS"
				});
				new Asset.javascript("apps/" + A + "/" + A + comp + ".js", {
					id :A + "JS",
					onload : function(C) {
						this.createWidget(A, B)
					}.bindWithEvent(this)
				})
			},
			launcherLoad : function(A) {
				new Asset.css("apps/" + A + "/" + A + comp + ".css", {
					id :A + "CSS"
				});
				new Asset.javascript("apps/" + A + "/" + A + comp + ".js", {
					id :A + "JS",
					onload : function(B) {
						this.createLauncher(A)
					}.bindWithEvent(this)
				})
			},
			createLauncher : function(A) {
				if (this.launchers[A]) {
					return false
				}
				lf.getInstance(A)
			},
			removeLauncher : function(A) {
				delete (this.launchers[A])
			},
			verifyLogin : function() {
				var B = this;
				var A = new Request.JSON(
						{
							url :"http://schmedley.com/js/verifyLogin.php",
							async :false,
							onComplete : function(C) {
								if (C.status == "success") {
									B.removeAllTabs();
									if (C.data.isRegistered == 1
											|| !B.inviteOnly) {
										B.configureDesktops(C.data.desktop);
										B.activate();
										if (C.data.forceNewPass == 1) {
											B.forceNewPass()
										}
									}
									B.userID = C.data.id;
									if (C.data.isRegistered == 1) {
										B.isRegistered = true;
										B.userName = C.data.userName;
										B.email = C.data.email;
										B.statusLoggedIn(C.data.userName);
										B.bugreport.setStyle("visibility",
												"visible")
									} else {
										B.bugreport.setStyle("visibility",
												"hidden");
										if (B.inviteOnly) {
											B.launchLogin()
										}
										B.isRegistered = false;
										B.userName = "";
										var D = new Element(
												"div",
												{
													"class" :"dockhint",
													html :"Move your mouse over the icons below to display their names and get a better idea of their function.<br />Clicking on the icons will launch new schmidgets (widgets / applications) onto your current desktop."
												});
										$(document.body).adopt(D);
										D.setStyle("display", "block");
										B.addDialogClose(D, null, {
											top :-9,
											left :14
										});
										( function() {
											schmedley.fade("out", D)
										}).delay(20000)
									}
								} else {
									B
											.showError("There was an error retrieving data from the Server.")
								}
							}
						});
				A.get()
			},
			configureDesktops : function(I) {
				if (I.tabs instanceof Array) {
					return
				}
				var H = 0;
				for ( var G in I.tabs) {
					var B = I.tabs[G];
					var C = this.addDesktop(G, B);
					if (B.active == 1) {
						H = G;
						this.activeDesktopID = H
					}
				}
				for ( var E = 0; E < 2; E++) {
					for ( var G in I.tabs) {
						var B = I.tabs[G];
						if (E == 0 && B.active != 1) {
							continue
						}
						if (E == 1 && B.active == 1) {
							continue
						}
						if (B.widgets instanceof Array) {
							continue
						}
						var C = this.desktops[G];
						for ( var D in B.widgets) {
							var F = B.widgets[D];
							this.widgetParams[D] = F.widgetParams;
							C.addWidget(F.widgetName, D)
						}
					}
				}
				if (H > 0) {
					var A = this.tabs[H];
					if (A) {
						this.selectTab(A)
					}
				} else {
					for ( var E in this.tabs) {
						var B = this.tabs[E];
						B.selectTab();
						break
					}
				}
				this.updateColors()
			},
			newTab : function(B, F, D) {
				var C = this.getActiveTab();
				C.closeTabDialogs();
				if (B && !this.isLoggedIn) {
					if (this.newTabRegConfirm) {
						return
					}
					var A = this;
					this.newTabRegConfirm = this.showConfirm(gls("acp0")
							+ "<br />&nbsp;<br />" + gls("acp1"),
							this.launchSignup.bindWithEvent(this), function() {
								A.newTabRegConfirm = null
							});
					return
				}
				var A = this;
				var E = new Request.JSON( {
					url :"http://schmedley.com/js/addTab.php",
					async :true,
					onComplete : function(H) {
						if (H) {
							if (H.status == "success") {
								var G = H.data.tabID;
								H.data.gradient = 0;
								H.data.active = true;
								H.data.name = H.data.tabName;
								A.addDesktop(G, H.data)
							} else {
								A.alert(H.data.reason)
							}
						} else {
							A.alert("Unable to add Tab/Desktop")
						}
					}
				});
				if (!F || F == "") {
					F = gls("tab1")
				}
				E.get( {
					tn :F,
					bg :dfbg,
					iwt :D
				})
			},
			addTabZero : function() {
				this.addDesktop(0, {
					name :gls("tab0"),
					bgcolor :dfbg,
					gradient :0,
					active :true
				})
			},
			getElWidget : function(A) {
				if (this.widgets[A.id]) {
					return this.widgets[A.id]
				} else {
					while (A.getParent()) {
						A = A.getParent();
						if (this.widgets[A.id]) {
							return this.widgets[A.id]
						}
					}
				}
				return null
			},
			getElTab : function(A) {
				if (this.tabs[A]) {
					return this.tabs[A]
				}
				return null
			},
			launchLogin : function() {
				if (this.loginDialog) {
					if (this.loginDialog.destroy) {
						this.loginDialog.destroy()
					}
					delete this.loginDialog
				}
				this.loginDialog = new Element("div", {
					id :"login",
					"class" :"logdlg"
				});
				var H = new Element("h1", {
					html :gls("log0")
				});
				H.injectInside(this.loginDialog);
				var B = new Element("p", {
					html :gls("log1") + "&nbsp;:&nbsp;&nbsp;"
				});
				B.setStyle("margin-left", "117px");
				B.injectInside(this.loginDialog);
				var F = new Element("input", {
					type :"text",
					value :"",
					id :"un"
				});
				F.setStyle("width", "120px");
				F.injectInside(B);
				var I = new Element("div", {
					html :gls("log2") + "&nbsp;:&nbsp;&nbsp;"
				});
				I.setStyles( {
					"margin-left" :"117px",
					"float" :"left"
				});
				I.injectInside(this.loginDialog);
				var D = new Element("div");
				D.setStyles( {
					"float" :"left"
				});
				D.injectInside(this.loginDialog);
				var J = new Element("input", {
					type :"password",
					value :"",
					id :"pw"
				});
				J.setStyle("width", "120px");
				J.injectInside(D);
				var E = new Element("span", {
					html :"&nbsp;&nbsp;&nbsp;(" + gls("log3") + ")"
				});
				E.setStyles( {
					"font-style" :"italic",
					"font-size" :"10px",
					"margin-top" :"-4px"
				});
				E.injectAfter(J);
				var C = new TextField(J, null, null, this.login
						.bindWithEvent(this));
				new Button("i", this.loginDialog, "loginGo", "b", 214, 140,
						gls("but8"), this.login.bindWithEvent(this), "");
				var G = new Element("div");
				G.setStyles( {
					position :"absolute",
					top :"182px",
					left :"11px",
					width :"458px",
					"font-size" :"10px",
					"text-align" :"center"
				});
				var A = new Element("a", {
					id :"forgotPW",
					href :"#",
					html :gls("log4")
				}).injectInside(G);
				G.injectInside(D);
				var K = this;
				A.removeEvents("click");
				A.addEvent("click", function() {
					K.retrieveUserPass();
					return false
				});
				this.loginDialog.setOpacity(0);
				this.loginDialog.injectInside($("horizon"));
				if (!this.inviteOnly) {
					this.addDialogClose(this.loginDialog)
				}
				this.fade("in", this.loginDialog);
				F.focus()
			},
			login : function() {
				var A = this.loginDialog;
				var D = document.getElementById("un");
				var C = document.getElementById("pw").value;
				var E = this;
				var B = new Request.JSON( {
					url :"http://schmedley.com/js/login.php",
					onComplete : function(F) {
						if (F.status == "success") {
							E.fade("out", A);
							A.destroy.bindWithEvent(A).delay(1000);
							E.removeAllTabs();
							E.statusLoggedIn(F.data.userName);
							E.configureDesktops(F.data.desktop);
							E.activate();
							if (F.data.forceNewPass == 1) {
								E.forceNewPass()
							}
							E.isRegistered = true;
							E.userID = F.data.id;
							E.userName = F.data.userName;
							E.email = F.data.email;
							$("buggy").setStyle("visibility", "visible")
						} else {
							alert("Login Failed.<br/>" + F.data.reason)
						}
					}
				});
				B.get( {
					u :D.value,
					p :C
				})
			},
			logout : function() {
				var C = this;
				var B = new Request( {
					url :"http://schmedley.com/js/logout.php",
					async :false,
					onComplete : function(D) {
						C.statusLoggedOut();
						C.verifyLogin()
					}
				});
				B.get();
				if (this.inviteOnly) {
					this.removeDockEvents();
					var A = $("tabAdd");
					A.removeEvents("click")
				}
			},
			retrieveUserPass : function() {
				if (this.loginDialog) {
					this.fade("out", this.loginDialog)
				}
				this.upDialog = new Element("div", {
					id :"upDialog",
					"class" :"fupdlg"
				});
				this.upDialog.setOpacity(0);
				this.upDialog.injectInside($("horizon"));
				var F = new Element("h1", {
					html :gls("rup0") + " / " + gls("rup1")
				});
				F.injectInside(this.upDialog);
				var H = new Element("p", {
					html :gls("sup3") + "&nbsp;:&nbsp;&nbsp;"
				});
				H.setStyles( {
					"margin-left" :"74px",
					"margin-top" :"40px"
				});
				H.injectInside(this.upDialog);
				var E = new Element("input", {
					type :"text",
					value :"",
					id :"upEmail"
				});
				E.injectInside(H);
				H = new Element("p", {
					html :gls("sup12") + "&nbsp;:&nbsp;&nbsp;"
				});
				H.setStyles( {
					"margin-left" :"55px",
					"margin-top" :"25px"
				});
				H.injectInside(this.upDialog);
				var G = new Element("img", {
					src :"http://schmedley.com/js/captcha.php?r="
							+ Math.random(),
					id :"forgotCaptchaImg"
				});
				G.setStyles( {
					width :"160px",
					height :"40px",
					border :"0px"
				});
				G.injectInside(H);
				H = new Element("p");
				H.setStyles( {
					"margin-top" :"-10px",
					"margin-left" :"163px"
				});
				H.injectInside(this.upDialog);
				var D = new Element("input", {
					type :"text",
					value :"",
					id :"captcha"
				});
				D.setStyles( {
					width :"90px"
				});
				D.injectInside(H);
				D.addEvent("keypress", this.stopReturn);
				H.appendText("\u00A0");
				var B = new Element("a", {
					href :"#",
					html :gls("sup13")
				});
				B.addEvent("click", function() {
					G.set("src", "http://schmedley.com/js/captcha.php?r="
							+ Math.random());
					return false
				});
				B.injectInside(H);
				var C = this;
				this.upSpinner = new Element("img", {
					src :"http://schmedley.com/js/css/img/spinner-bt.gif"
				});
				this.upSpinner.setStyles( {
					position :"absolute",
					left :"225px",
					top :"250px",
					display :"none"
				});
				this.upSpinner.injectInside(this.upDialog);
				var A = new Button("i", this.upDialog, "upUsername", "b", 42,
						250, gls("rup0"), null, "");
				A.onClick = function() {
					C.sendUsername(E.value, D.value)
				};
				A = new Button("i", this.upDialog, "upPassword", "b", 331, 250,
						gls("rup1"), null, "");
				A.onClick = function() {
					C.sendPassword(E.value, D.value)
				};
				this.addDialogClose(this.upDialog);
				this.fade("in", this.upDialog);
				E.focus()
			},
			sendUsername : function(C, B) {
				if (C == "") {
					alert("You need to provide an email address");
					return false
				}
				this.upSpinner.setStyle("display", "block");
				var A = this;
				var D = new Request.JSON(
						{
							url :"http://schmedley.com/js/sendUsername.php",
							onComplete : function(E) {
								if (E.status == "success") {
									if (A.upDialog) {
										A.fade("out", A.upDialog);
										A.upDialog.destroy.bindWithEvent(
												A.upDialog).delay(1000)
									}
									alert("An Email containing your username has been sent to "
											+ C)
								} else {
									if (E.status == "error") {
										A.upSpinner.setStyle("display", "none");
										alert(E.data.reason)
									}
								}
							}
						});
				D.send("e=" + C + "&c=" + B);
				this.launchLogin.delay(1000, this)
			},
			sendPassword : function(C, B) {
				if (C == "") {
					alert("You need to provide an email address");
					return false
				}
				this.upSpinner.setStyle("display", "block");
				var A = this;
				var D = new Request.JSON(
						{
							url :"http://schmedley.com/js/sendPassword.php",
							onComplete : function(E) {
								if (E.status == "success") {
									if (A.upDialog) {
										A.fade("out", A.upDialog);
										A.upDialog.destroy.bindWithEvent(
												A.upDialog).delay(1000)
									}
									alert("An Email containing your new password has been sent to "
											+ C)
								} else {
									if (E.status == "error") {
										A.upSpinner.setStyle("display", "none");
										alert(E.data.reason)
									}
								}
							}
						});
				D.send("e=" + C + "&c=" + B);
				this.launchLogin.delay(1000, this)
			},
			forceNewPass : function() {
				var A = this;
				new Prompt("Please enter a new schmedley password.", true,
						A.setNewPass.bindWithEvent(this), {
							password :true,
							"confirm password" :true
						}, true)
			},
			setNewPass : function(A) {
				if (!this.validatePass(A[0].value, A[1].value)) {
					A[0].focus();
					return false
				}
				var B = this;
				var C = new Request.JSON( {
					url :"http://schmedley.com/js/setPassword.php",
					onComplete : function(D) {
						if (D.status == "success") {
							alert("Your password has been changed.")
						} else {
							if (D.status == "error") {
								alert(D.data.reason)
							}
						}
						B.blackOut("out")
					}
				});
				C.send("p=" + A[0].value);
				return true
			},
			launchSignup : function() {
				if (this.inviteOnly) {
					return false
				}
				if (this.signupDialog) {
					return
				}
				var C = this.loginDialog;
				if (C) {
					if (C.fade) {
						this.fade("out", C)
					}
					if (C.destroy) {
						C.destroy()
					}
				}
				var E = new Element("div", {
					id :"signupDialog",
					"class" :"supdlg"
				});
				E.setOpacity(0);
				E.injectInside($("horizon"));
				E
						.set(
								"html",
								"<h1>"
										+ gls("sup0")
										+ '</h1><form id="signupForm"><div class="l">'
										+ gls("sup1")
										+ ' :</div><div class="r"><input name="firstname" type="text" value="" style="width: 120px;" onkeypress="return schmedley.stopReturn(event);" /></div><div class="l">'
										+ gls("sup2")
										+ ' :</div><div class="r"><input name="lastname" type="text" value="" style="width: 120px;" onkeypress="return schmedley.stopReturn(event);" /></div><div class="l">'
										+ gls("sup3")
										+ ' :</div><div class="r"><input name="email" type="text" value="" style="width: 175px;" onkeypress="return schmedley.stopReturn(event);" /></div><div style="clear: both; height: 1px;">&nbsp;</div><div class="l">'
										+ gls("sup4")
										+ ' :</div><div class="r"><input name="sex" type="radio" value="m" />&nbsp;'
										+ gls("sup5")
										+ '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name="sex" type="radio" value="f" />&nbsp;'
										+ gls("sup6")
										+ '</div><div class="l">'
										+ gls("sup7")
										+ ' :</div><div class="r"><input name="dobMonth" type="text" size="2" maxlength="2" onkeypress="return schmedley.stopReturn(event);" style="width: 16px;" /> . <input name="dobDay" type="text" size="2" maxlength="2" onkeypress="return schmedley.stopReturn(event);" style="width: 16px;" /> . <input name="dobYear" type="text" size="4" maxlength="4" onkeypress="return schmedley.stopReturn(event);" style="width: 30px;" />&nbsp;&nbsp;<span style="font-size: 10px;"><i>( '
										+ gls("sup8")
										+ ' )</i></span></div><div style="clear: both; height: 3px;">&nbsp;</div><div class="l">'
										+ gls("sup9")
										+ ' :</div><div class="r"><input name="username" type="text" value="" style="width: 120px;" onkeypress="return schmedley.stopReturn(event);" /></div><div class="l">'
										+ gls("sup10")
										+ ' :</div><div class="r"><input name="password" type="password" value="" style="width: 120px;" onkeypress="return schmedley.stopReturn(event);" /></div><div class="l">'
										+ gls("sup11")
										+ ' :</div><div class="r"><input name="confirm" type="password" value="" style="width: 120px;" onkeypress="return schmedley.stopReturn(event);" /></div><div style="clear: both; height: 3px;">&nbsp;</div><div class="l">&nbsp;</div><div class="r" style="height: 45px;"><img id="captchaImg" src="captcha.php" style="width: 160px; height: 40px; border: 0px;" /></div><div class="l">'
										+ gls("sup12")
										+ ' :</div><div class="r" style="font-size: 10px;"><input name="captcha" type="text" value="" style="width: 90px; margin-right: 10px;" onkeypress="return schmedley.stopReturn(event);" /><a href="#" onclick="$(\'captchaImg\').set(\'src\', \'http://schmedley.com/js/captcha.php?r=\' + Math.random()); return false;">'
										+ gls("sup13")
										+ '</a></div><div class="agree"><input type="checkbox" name="agree" />&nbsp;'
										+ gls("sup14")
										+ '&nbsp;<a href="http://blog.schmedley.com/about/privacy-policy/" target="_new">'
										+ gls("sup15")
										+ "</a>&nbsp;"
										+ gls("sup16")
										+ '&nbsp;<a href="http://blog.schmedley.com/about/terms-of-use/" target="_new">'
										+ gls("sup17") + "</a>.</div></form>");
				var B = this;
				if (!this.registerOnly) {
					this.addDialogClose(E, function() {
						B.signupDialog = null
					})
				}
				var A = new Button("i", "signupDialog", "signupGo", "b", 214,
						457, gls("but7"), null, "");
				A.onClick = this.signUp.bindWithEvent(B, A);
				var D = 480;
				var F = A.el.clientWidth;
				A.el.setStyle("left", ((D - F) / 2) + "px");
				this.signupDialog = E;
				this.fade("in", E)
			},
			stopReturn : function(C) {
				var B = new Event(C);
				var A = B.key;
				if (A == "return" || A == "enter") {
					B.stop();
					return false
				}
				return true
			},
			signUp : function(H, E) {
				E.disable();
				var G = $("signupDialog");
				var A = $("signupForm");
				var F = [ "firstname", "lastname", "email", "username",
						"password" ];
				var O = "";
				for ( var D = 0; D < F.length; D++) {
					if (A[F[D]].value.trim() == "") {
						O += "Please provide a value for " + F[D] + "<br />"
					}
				}
				if (O != "") {
					alert(O);
					E.enable();
					return false
				}
				unLimit = 16;
				if (A.username.value.length > unLimit) {
					A.username.value = A.username.value.substring(0, unLimit);
					alert("Sorry, usernames are limited to " + unLimit
							+ " characters.");
					return false
				}
				var J = /^[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
				var M = A.email.value;
				if (!M.match(J)) {
					alert("Please Enter a valid Email Address.");
					A.email.focus();
					E.enable();
					return false
				}
				var L = A.password.value;
				var C = A.confirm.value;
				if (!this.validatePass(L, C)) {
					E.enable();
					return false
				}
				var B = new Date();
				if (!A.dobMonth.value.match(/[0-9]{1,2}/)
						|| A.dobMonth.value > 12) {
					alert("DOB Month is invalid.");
					E.enable();
					return false
				}
				if (!A.dobDay.value.match(/[0-9]{1,2}/) || A.dobDay.value > 31) {
					alert("DOB Day is invalid.");
					E.enable();
					return false
				}
				if (!A.dobYear.value.match(/[0-9]{4}/)
						|| A.dobYear.value > B.getFullYear()
						|| A.dobYear.value < B.getFullYear() - 110) {
					alert("DOB Year is invalid.");
					E.enable();
					return false
				}
				if (!A.agree.checked) {
					alert('To complete you registration, you must check the box signifying that you agree with our "Privacy Policy" and "Terms of Use".');
					E.enable();
					return false
				}
				var N = this;
				var K = new Request.JSON(
						{
							url :"http://schmedley.com/js/register.php",
							onComplete : function(P) {
								if (P.status == "success") {
									N.fade("out", G);
									G.destroy.bindWithEvent(G).delay(1000);
									alert("Thanks for signing up.  You'll receive a confirmation email shortly.")
								} else {
									if (P.status == "error") {
										if (P.data.scope == "register_username_inuse") {
											A.username.focus()
										}
										if (P.data.scope == "register_email_inuse") {
											A.email.focus()
										}
										alert(P.data.reason);
										E.enable();
										return false
									}
								}
							}
						});
				var I = "";
				for ( var D = 0; D < A.sex.length; D++) {
					if (A.sex[D].checked) {
						I = A.sex[D].value
					}
				}
				K.post( {
					firstName :A.firstname.value,
					lastName :A.lastname.value,
					email :M,
					sex :I,
					dob :A.dobYear.value + "-" + A.dobMonth.value + "-"
							+ A.dobDay.value,
					userName :A.username.value,
					password :L,
					captcha :A.captcha.value
				})
			},
			validatePass : function(B, A) {
				if (B.length < 8) {
					alert("Password must be at least 8 characters.");
					return false
				}
				if (B != A) {
					alert("Passwords do not match.");
					button.enable();
					return false
				}
				return true
			},
			removeAllTabs : function() {
				var B = /^tab([0-9]*)$/;
				for ( var F in this.tabs) {
					var C = this.tabs[F];
					var D = "desk" + F;
					var E = "css" + F;
					var A = "dialog" + F;
					$(D).destroy();
					if ($(E)) {
						$(E).destroy()
					}
					if ($(A)) {
						$(A).destroy()
					}
					C.destroy()
				}
				this.tabs = new Object();
				this.desktops = new Object()
			},
			getActiveDesk : function() {
				var B = this.desktops[this.activeDesktopID];
				if (!B) {
					for ( var A in this.desktops) {
						B = this.desktops[A];
						this.activeDesktopID = A;
						break
					}
				}
				return B
			},
			getActiveTab : function() {
				var B = this.tabs[this.activeDesktopID];
				if (!B) {
					for ( var A in this.tabs) {
						B = this.tabs[A];
						this.activeDesktopID = A;
						break
					}
				}
				return B
			},
			statusLoggedIn : function(C) {
				var E = document.getElementById("signin");
				E.destroy();
				E = new Element("div", {
					id :"loggedin",
					html :C
				}).injectTop($("infobox"));
				var D = $("signup");
				D.destroy();
				var A = new Button("i", "infobox", "logout", "b", 35, 14,
						gls("but9"), this.logout.bindWithEvent(this), "");
				this.isLoggedIn = true;
				var B = this;
				B.shimmyLogin(E)
			},
			statusLoggedOut : function() {
				var B = document.getElementById("loggedin");
				B.destroy();
				loggedIn = new Element("div", {
					id :"signin",
					html :gls("but8")
				}).addEvent("click", this.launchLogin.bindWithEvent(this))
						.injectTop($("infobox"));
				var A = $("logout");
				A.destroy();
				new Button("i", "infobox", "signup", "b", 35, 14, gls("but7"),
						this.launchSignup.bindWithEvent(this), "");
				this.isLoggedIn = false;
				this.shimmyLogin(loggedIn)
			},
			addDialogClose : function(E, A, C) {
				var F = new Element("img", {
					"class" :"dialogClose",
					src :"css/img/dialogClose.png",
					alt :"Close"
				});
				if (C) {
					for ( var D in C) {
						switch (D) {
						case "top":
							var H = C[D];
							break;
						case "left":
							var G = C[D];
							break
						}
					}
				}
				if (!H) {
					var H = 0
				}
				if (!G) {
					var G = 25
				}
				F.setStyles( {
					top :H + "px",
					left :(E.offsetWidth - G) + "px"
				});
				E.appendChild(F);
				var B = this;
				F.addListener("click", function() {
					B.fade("out", E);
					E.destroy.delay(1000, E);
					if (A && A.call) {
						A.call()
					}
				})
			},
			hideFlashWidgets : function() {
				for ( var A in this.widgets) {
					var B = this.widgets[A];
					if (B.isFlash) {
						B.el.setStyle("visibility", "hidden")
					}
				}
			},
			restoreFlashWidgets : function() {
				var B = this.getActiveDesk();
				for ( var A in this.widgets) {
					var C = this.widgets[A];
					if (C.isFlash && C.desk == B) {
						C.el.setStyle("visibility", "visible")
					}
				}
			},
			alert : function(A) {
				this.hideFlashWidgets();
				this.showError(A)
			},
			showError : function(A) {
				new Alert(A, this.restoreFlashWidgets.bind(this))
			},
			showConfirm : function(B, A, C) {
				return new Confirm(B, A, C)
			},
			blackOut : function(A) {
				if (A == "in") {
					this.hideFlashWidgets();
					this.bo.setStyles( {
						opacity :0,
						visibility :"visible",
						display :"block",
						height :window.getHeight(),
						width :window.getWidth()
					});
					this.bos.setStyles( {
						display :"block",
						visibility :"visible",
						height :window.getHeight(),
						width :window.getWidth()
					});
					this.fade(A, this.bo)
				} else {
					this.restoreFlashWidgets();
					this.fade(A, this.bo);
					this.hideBlackOut.bindWithEvent(this).delay(400)
				}
			},
			hideBlackOut : function() {
				this.bo.setStyles( {
					display :"none"
				})
			},
			getNumTabs : function() {
				var A = 0;
				for ( var B in this.tabs) {
					A++
				}
				return A
			},
			canDeleteTab : function() {
				if (this.getNumTabs() <= 1) {
					return false
				}
				return true
			},
			removeTabRef : function(A) {
				if (this.tabs[A.dbID]) {
					delete this.tabs[A.dbID]
				}
			},
			fade : function(A, B, D, C) {
				if (!C) {
					var C = new Fx.Morph(B)
				} else {
					C.cancel()
				}
				if ((typeof D) == "function") {
					C.chain(D)
				}
				switch (A) {
				case "in":
					var C = new Fx.Morph(B);
					if (this.useFade) {
						return C.start( {
							opacity :1
						})
					} else {
						return C.set( {
							opacity :1
						})
					}
					break;
				case "out":
					if (this.useFade) {
						return C.start( {
							opacity :0
						})
					} else {
						return C.set( {
							opacity :0
						})
					}
					break
				}
				return C
			},
			adjustLayout : function() {
				$$("div.dsktp").setStyle("height", "100%");
				var E = window.getHeight();
				var C = window.getScrollSize().y;
				var G = document.body.scrollHeight;
				var A = window.getWidth();
				B();
				if (Browser.Engine.webkit == true) {
					if (G > E) {
						$$("div.dsktp").setStyle("height", G + "px");
						$("rite").setStyle("left", (A - 160) + "px")
					} else {
						$$("div.dsktp").setStyle("height", E + "px");
						$("rite").setStyle("left", (A - 145) + "px")
					}
				} else {
					if (C > E) {
						$$("div.dsktp").setStyle("height", C + "px");
						$("rite").setStyle("left", (A - 145) + "px")
					} else {
						$$("div.dsktp").setStyle("height", E + "px");
						$("rite").setStyle("left", (A - 145) + "px")
					}
				}
				$("rite").style.display = "block";
				$("tabs").style.width = (A - 400) + "px";
				$("horizon").style.top = (E / 2) + "px";
				$("horizon").style.width = (A - 40) + "px";
				function B() {
					D();
					var J = schmedley.getActiveDesk();
					if (E < 1020) {
						var H = $("ad5");
						if (H) {
							H.setStyle("display", "none")
						}
					}
					if (E < 875) {
						var I = $("ad4");
						if (I) {
							I.setStyle("display", "none")
						}
					}
					if (E < 730) {
						var L = $("ad3");
						if (L) {
							L.setStyle("display", "none")
						}
					} else {
					}
					var M = $("ad1");
					var K = $("adSpace");
					if (M && K) {
						K.setStyles( {
							display :"block",
							visibility :"visible"
						})
					}
				}
				function D() {
					for ( var H = 1; H <= 5; H++) {
						$$("#ad1, #ad2, #ad3, #ad4, #ad5").setStyle("display",
								"block")
					}
				}
				var F = schmedley.getActiveTab();
				if (F) {
					schmedley.setPrivacyStyles(F.privacy, false)
				}
			},
			storeInCookie : function(A, B) {
				if (!(this.cookieData instanceof Object)) {
					this.cookieData = new Object()
				}
				this.cookieData[A] = B;
				Cookie.write(this.cookieName, JSON.encode(this.cookieData), {
					duration :365,
					domain :this.domain
				})
			},
			getCookieValue : function(A) {
				if (!(this.cookieData instanceof Object)) {
					return null
				}
				return this.cookieData[A]
			},
			removeCookieValue : function(A) {
				if (!(this.cookieData instanceof Object)) {
					return false
				}
				delete (this.cookieData[A]);
				return true
			},
			escape64 : function(A) {
				return escape(A).replace("+", "%2b")
			},
			bugReport : function() {
				window.open("http:http://bugs.schmedley.com/?user=/"
						+ this.userName + "&email=" + this.email)
			},
			shimmyLogin : function(C) {
				var A = 135;
				var B = C.clientWidth;
				C.setStyle("left", ((A - B - 4) / 2) + "px")
			},
			closeColor : function() {
				var C = $("ColourMod");
				if (C) {
					C.empty()
				}
				for ( var B in this.desktops) {
					var A = this.desktops[B];
					A.colorOpen = false
				}
				this.updateColors()
			},
			updateColors : function() {
				var B = this.tabs[this.activeDesktopID];
				if (B) {
					B.adjustTabFontColor()
				}
				var C = this.getActiveDesk().el.getStyle("background-color");
				if (C == "transparent") {
					C = dfbg
				}
				if (this.colorIsLight(C) == true) {
					$("infobox").addClass("dark");
					$("copy").addClass("dark");
					document.body.addClass("dark")
				} else {
					$("copy").removeClass("dark");
					$("infobox").removeClass("dark");
					document.body.removeClass("dark")
				}
				var E = "desk" + this.activeDesktopID;
				var D = $(E).getFirst();
				if (D) {
					var A = D.className;
					if (A.indexOf("1") != -1) {
						$("infobox").removeClass("dark");
						document.body.removeClass("dark")
					}
					if (A.indexOf("2") != -1) {
						$("copy").removeClass("dark")
					}
				}
			},
			colorIsLight : function(B) {
				var A = B.hexToRgb(true);
				var C = A.every( function(E, D) {
					return E > 170
				});
				return C
			},
			draggingWidget : function(A) {
				this.isDragging = A
			},
			manageColor : function(C) {
				var E = this.getActiveDesk();
				if (!E) {
					return
				}
				if (E.colorOpen) {
					return
				}
				E.colorOpen = true;
				var G = new Event(C);
				var H = G.target;
				var I = new Element("div", {
					id :"cmDefault"
				});
				I
						.set(
								"html",
								'<div id="cmColorBox"></div><div id="cmSatValBg"></div><img src="css/img/colour-bg.png" id="cmOverlay" alt="" /><div id="cmTop"></div><div id="cmSatValBox"><div id="cmDot" class="cmDot"></div></div><div id="cmHueBox"><div id="cmArrow" class="cmArrow"></div></div><h1>' + gls("gui0") + '</h1><input type="text" name="cmHex" id="cmHex" value="" maxlength="6" /><a id="cmClose" src="css/img/but-x.png" alt="Close" title="Close" /></a><div id="cmHueValBox"><input type="text" name="cmHue" id="cmHue" value="0" maxlength="3" /></div>');
				var D = E.el.getStyle("background-color");
				var J = D.replace(/#/, "");
				if (J.length == 3) {
					var A = J.substring(0, 1) + "";
					var B = J.substring(1, 2) + "";
					var F = J.substring(2, 3) + ""
				}
				I.injectInside($("ColourMod"));
				pickColor("#desk" + schmedley.activeDesktopID, "background", H);
				$("cmHex").value = J;
				hexUpdate()
			}
		});
var Desktop = new Class( {
	initialize : function(G, E, A, D, F, B) {
		this.app = E;
		this.widgets = new Array();
		this.dbID = G;
		this.id = "desk" + G;
		this.isPublicView = B;
		var C = new Element("div", {
			id :this.id,
			"class" :"dsktp"
		});
		if (!B) {
			C.injectBefore("tabs")
		} else {
			C.injectInside(document.body)
		}
		this.el = C;
		this.el.setStyle("background-color", A);
		if (D && D != "") {
			gradeState = 0;
			this.setBGImage(D, true)
		}
		if (F != 0) {
			this.createGradient(F)
		} else {
			this.gradState = 0
		}
		this.colorOpen = false
	},
	isActive : function() {
		return (schmedley.activeDesktopID == this.dbID)
	},
	addWidget : function(D, C, A) {
		var B = this;
		if (this.isActive()) {
			wf.getInstance(D, C, this, A)
		} else {
			( function() {
				wf.getInstance(D, C, B, A)
			}).delay(1500)
		}
	},
	finishAddWidget : function(A) {
		if (!A) {
			return
		}
		var B = schmedley.widgetParams[A.dbID];
		if (!B) {
			B = new Object()
		}
		A.parseOuterParams(B, (this.dbID == schmedley.activeDesktopID));
		this.widgets[this.widgets.length] = A;
		schmedley.widgets[A.el.id] = A;
		A.postInit();
		A.parseInnerParams(schmedley.widgetParams[A.dbID])
	},
	getOpenPosition : function(B) {
		var A = window.getScrollSize();
		var L = window.getSize();
		var I = schmedley.getDimensions(B).w;
		var F = schmedley.getDimensions(B).h;
		var D = Math.floor(L.x - I) / 2;
		var K = Math.floor(A.y - F) / 2;
		var J = false;
		var H = 0;
		while (!J) {
			var E;
			for (E = 0; E < this.widgets.length; E++) {
				var C = this.widgets[E];
				if ((D + "px" == C.el.getStyle("left") || K + "px" == C.el
						.getStyle("top"))) {
					break
				}
			}
			if (E == this.widgets.length) {
				J = true;
				break
			}
			H++;
			D += 50;
			K += 50
		}
		var G = {
			0 :D,
			1 :K
		};
		return G
	},
	closeWidget : function(A) {
		this.widgets.remove(A)
	},
	showWidgets : function() {
		for (i = 0; i < this.widgets.length; i++) {
			var A = this.widgets[i];
			A.el.setStyle("opacity", 1)
		}
	},
	ZindexToTop : function(B) {
		var D = this.widgets.length;
		if (D > 1) {
			var C = new Hash();
			for (i = 0; i < this.widgets.length; i++) {
				var F = this.widgets[i];
				if (F == B) {
					B.el.setStyle("zIndex", D)
				} else {
					C.set(F.el.getStyle("zIndex"), F.el)
				}
			}
			var A = C.getKeys().sort(this.sortNumber);
			var G = new Object();
			for (i = 0; i < A.length; i++) {
				var E = C.get(A[i]);
				E.setStyle("zIndex", i + 1);
				var F = schmedley.getElWidget(E);
				G[F.dbID] = i + 1
			}
			G[B.dbID] = i + 1;
			this.updateZIndices(G)
		}
	},
	sortNumber : function(B, A) {
		return B - A
	},
	widgetMouseDown : function(A) {
		A.el.setStyle("padding-bottom", "69px");
		this.ZindexToTop(A)
	},
	widgetMouseMove : function(A) {
	},
	widgetMouseUp : function(A) {
		schmedley.adjustLayout();
		if (A) {
			if (A.x != A.el.style.left || A.y != A.el.style.top) {
				A.savePosition(A.el.style.left, A.el.style.top);
				A.updateParams( {
					x :A.el.style.left,
					y :A.el.style.top
				})
			}
		} else {
		}
		( function() {
			A.el.setStyle("padding-bottom", "0px")
		}).delay(250)
	},
	updateColor : function() {
		var A = new Request.JSON( {
			url :"http://schmedley.com/js/modifyTab.php",
			async :true
		});
		A.get( {
			tid :this.dbID,
			bg :this.el.getStyle("background-color")
		})
	},
	toggleGradient : function(C) {
		if (this.bgDiv && C != 0) {
			return
		}
		if (this.gradientDiv) {
			var B = this.gradientDiv.className.toString();
			var A = B.charAt(B.length - 2);
			this.gradientDiv.destroy();
			delete this.gradientDiv;
			if (A != C) {
				this.createGradient(C);
				this.updateGradState(C)
			} else {
				this.updateGradState(0);
				this.gradState = 0
			}
		} else {
			this.createGradient(C);
			this.updateGradState(C)
		}
	},
	createGradient : function(B) {
		this.gradState = B;
		var A = window.innerHeight;
		if (A > 900) {
			s = "grad" + B + "l"
		} else {
			s = "grad" + B + "s"
		}
		this.gradientDiv = new Element("div", {
			"class" :s
		});
		this.gradientDiv.injectTop(this.el)
	},
	updateGradState : function(B) {
		var A = new Request.JSON( {
			url :"http://schmedley.com/js/modifyTab.php",
			async :true
		});
		A.get( {
			tid :this.dbID,
			g :B
		})
	},
	setBGImage : function(G, F) {
		if (this.gradientDiv) {
			this.gradientDiv.destroy();
			delete this.gradientDiv
		}
		var B = window.innerWidth;
		var D = window.innerHeight;
		var A = false;
		if (G == "") {
			if (this.bgDiv) {
				this.bgDiv.destroy();
				delete this.bgDiv
			}
		} else {
			if (G.indexOf("wp") != -1) {
				A = true;
				var H = ""
			} else {
				var H = "e";
				if ((B <= 1680) && (D <= 1050)) {
					H = "d"
				}
				if ((B <= 1440) && (D <= 900)) {
					H = "c"
				}
				if ((B <= 1280) && (D <= 800)) {
					H = "b"
				}
				if ((B <= 1024) && (D <= 640)) {
					H = "a"
				}
			}
			var C = G;
			G = G.replace(/t\.jpg/, H + ".jpg");
			if (!this.bgDiv) {
				this.bgDiv = new Element("div", {})
			}
			if (A) {
				this.bgDiv.setStyles( {
					"background-image" :"url(" + G + ")",
					"background-position" :"top center",
					"background-repeat" :"repeat",
					"background-attachment" :"fixed",
					width :"100%",
					height :"100%"
				})
			} else {
				this.bgDiv.setStyles( {
					"background-image" :"url(" + G + ")",
					"background-position" :"top center",
					"background-repeat" :"no-repeat",
					"background-attachment" :"fixed",
					width :"100%",
					height :"100%"
				})
			}
			this.bgDiv.setStyles( {
				width :"100%",
				height :"100%",
				"background-image" :"url(" + G + ")"
			});
			this.bgDiv.inject(this.el, "top")
		}
		if (!F) {
			var E = new Request.JSON( {
				url :"http://schmedley.com/js/modifyTab.php"
			});
			if (C && C != "") {
				C = C.replace(/http:\/\/[^\/]*/, "")
			} else {
				C = ""
			}
			E.get( {
				tid :this.dbID,
				bi :C
			})
		}
	},
	updateZIndices : function(B) {
		if (this.isPublicView) {
			return
		}
		var A = new Request( {
			url :"http://schmedley.com/js/updateZIndices.php",
			async :true
		});
		A.get( {
			ind :JSON.encode(B)
		})
	},
	setBGColor : function(A) {
		this.el.setStyle("background-color", A)
	},
	destroy : function() {
		this.el.destroy()
	},
	closeWidget : function(A) {
		this.widgets.erase(A)
	}
});
var Tab = new Class(
		{
			initialize : function(H, G, M, C, B, L) {
				this.desk = G;
				this.dbID = G.dbID;
				this.id = "tab" + this.dbID;
				this.deskName = H;
				this.manageDialog = null;
				this.privacy = C;
				this.tabURLName = B;
				this.defaultTab = L;
				var E = new Element("li", {
					id :this.id,
					"class" :"tab"
				});
				var A = new Element("div", {
					"class" :"tabl"
				});
				this.tabl = A;
				if (M != 1) {
					var D = new Element("div", {
						"class" :"tabi",
						title :gls("tab2")
					});
					D.addListener("click", this.manageTab.bindWithEvent(this));
					this.tabi = D
				}
				var I = new Element("div", {
					"class" :"tabc",
					id :this.id + "t"
				}).addEvent("click", this.selectTab.bindWithEvent(this)).set(
						"html", H);
				var N = new Element("div", {
					"class" :"tabr"
				});
				var K = new Element("div", {
					"class" :"tabx",
					title :gls("tab4")
				});
				K.addListener("click", this.removeTab.bindWithEvent(this));
				this.closeButton = K;
				E.appendChild(A);
				if (M != 1) {
					A.appendChild(D)
				}
				E.appendChild(I);
				E.appendChild(N);
				N.appendChild(K);
				var F = $("tabAdd").getPrevious("li");
				if (F) {
					var J = F.id;
					E.injectAfter(J)
				} else {
					E.injectTop($("tabs"))
				}
				this.el = E;
				this.isWidgetTab = M;
				this.el.setOpacity(0.4);
				this.el.addEvent("mouseenter", function(O) {
					O = new Event(O).stop();
					if (!this.isActive) {
						this.el.setOpacity(0.7)
					}
				}.bindWithEvent(this));
				this.el.addEvent("mouseleave", function(O) {
					O = new Event(O).stop();
					if (!this.isActive) {
						this.el.setOpacity(0.4)
					}
				}.bindWithEvent(this));
				this.el
						.addEvent("mouseover", this.blinkDot
								.bindWithEvent(this));
				this.el.addEvent("mouseout", this.stopBlinkDot
						.bindWithEvent(this));
				this.showYellow(false)
			},
			selectTab : function() {
				this.closeTabDialogs();
				schmedley.selectTab(this);
				var A = new Request.JSON( {
					url :"http://schmedley.com/js/setActiveTab.php",
					async :true
				});
				A.get( {
					t :this.dbID
				})
			},
			active : function(A) {
				this.isActive = A;
				if (A) {
					this.el.setOpacity(1);
					this.desk.showWidgets();
					this.desk.el.setStyles( {
						"z-index" :"1",
						visibility :"visible",
						height :window.getHeight() + "px"
					});
					this.desk.el.setOpacity(1)
				} else {
					this.desk.el.setStyles( {
						"z-index" :"0",
						visibility :"hidden"
					});
					this.desk.el.setOpacity(0);
					this.el.setOpacity(0.4)
				}
			},
			destroy : function() {
				this.el.destroy()
			},
			saveTabName : function(A, B) {
				this.saveMods(A, {
					tn :B
				})
			},
			saveMods : function(D, F) {
				var C = this;
				var B = this.dbID;
				var A = this.el.getElement("http://schmedley.com/js/div.tabc");
				F.tid = B;
				var E = new Request.JSON(
						{
							url :"http://schmedley.com/js/modifyTab.php",
							async :true,
							onComplete : function(H) {
								if (H && H.status == "success") {
									var G = H.data.tabID;
									A.set("text", F.tn);
									if (F.p == "public") {
										for ( var J = 0; J < C.desk.widgets.length; J++) {
											var L = C.desk.widgets[J];
											if (L.canPublish != 1) {
												alert(gls("acp7"));
												break
											}
										}
									}
									if (H.data.defaultTab) {
										for ( var I in schmedley.tabs) {
											var K = schmedley.tabs[I];
											K.defaultTab = 0
										}
									}
									C.privacy = H.data.privacy;
									C.indexTab = H.data.indexTab;
									C.defaultTab = H.data.defaultTab;
									C.tabURLName = H.data.tabURLName;
									D.destroy();
									C.showYellow(false);
									schmedley.setPrivacyStyles(H.data.privacy,
											true)
								} else {
									schmedley.alert(gls("tabA"))
								}
							}
						});
				E.get(F)
			},
			closeTabDialogs : function() {
				var C = $$("div.tabdlg_l");
				C.each( function(D) {
					D.destroy()
				});
				C = $$("div.tabdlg_c");
				C.each( function(D) {
					D.destroy()
				});
				for ( var A in schmedley.tabs) {
					var B = schmedley.tabs[A];
					if (B) {
						B.showYellow(false)
					}
				}
			},
			manageTab : function() {
				var P = this;
				var Q = this.dbID;
				this.closeTabDialogs();
				var N = this.el.getTop() + 21;
				var H = this.el.getLeft();
				if (H <= 227) {
					var E = "tabdlg_l";
					var T = H - 20
				} else {
					var E = "tabdlg_c";
					var T = Math.max(0, this.el.getLeft() - 228)
				}
				var d = new Element("div", {
					id :"dialog" + this.dbID,
					"class" :E
				}).setStyles( {
					top :N + "px",
					left :T + "px",
					opacity :0
				}).inject(document.body);
				var V = new Element("h1", {
					html :gls("tab2")
				}).setStyles( {
					width :"412px",
					"text-align" :"center"
				}).inject(d);
				var b = new Element("div").setStyles( {
					position :"absolute",
					width :"145px",
					left :"15px",
					"text-align" :"right"
				}).inject(d);
				var e = new Element("div").setStyles( {
					position :"absolute",
					width :"150px",
					left :"165px"
				}).inject(d);
				var O = new Element("div").setStyles( {
					position :"absolute",
					width :"130px",
					left :"325px"
				}).inject(d);
				b.set("html", gls("tab3") + " : ");
				var S = this.el.getElement("http://schmedley.com/js/div.tabc")
						.get("text");
				var L = new Element("input", {
					type :"text",
					"class" :"tabName",
					value :S
				})
						.setStyles( {
							width :"144px",
							height :"14px"
						})
						.addEvent(
								"keypress",
								function(h) {
									var g = new Event(h);
									if ((this.value.length >= 32 && g.key != "backspace")
											|| !P.publicCharOK(g.key, g.code)) {
										g.stop();
										return false
									}
								}).addEvent("keyup", function() {
							J(escape(this.value))
						}).inject(e);
				var D = new Element("div").setStyles( {
					position :"absolute",
					top :"105px",
					"padding-top" :"10px",
					width :"410px",
					height :"65px",
					"border-top" :"1px solid #4f4f4f"
				});
				d.adopt(D);
				var B = new Element("div").setStyles( {
					position :"absolute",
					top :"160px"
				}).setOpacity(0);
				var A = new Element("div").setStyles( {
					position :"absolute",
					top :"155px",
					display :"block",
					width :"410px"
				});
				d.adopt(A);
				if (this.privacy == "public") {
					var c = gls("but12")
				} else {
					var c = gls("but2")
				}
				var W = new Button("i", A, "tpubbut" + Q, "b", 0, 105, c,
						function() {
							for ( var h in schmedley.tabs) {
								var j = schmedley.tabs[h]
							}
							var g = L.value;
							P.saveMods(this, {
								tn :g,
								tun :escape(P.publicName),
								p :K.checked ? "public" : "private",
								dt :a.checked ? 1 : 0,
								it :G.checked ? 1 : 0
							})
						}.bindWithEvent(d), "");
				var M = 410;
				var Z = $("tpubbut" + Q).getFirst().getNext().clientWidth + 20;
				$("tpubbut" + Q).setStyle("left", (M - Z) / 2 + "px");
				var Y = new Element("div").setStyles( {
					width :"100%",
					"border-top" :"1px solid #4f4f4f",
					position :"absolute",
					top :"143px",
					"text-align" :"left",
					"line-height" :"46px"
				}).appendText("post to :");
				A.adopt(Y);
				var C = new Button(
						"i",
						Y,
						"tfacebut" + Q,
						"b",
						50,
						10,
						"Facebook",
						function() {
							FB
									.ensureInit( function() {
										FB.Connect.requireSession();
										FB.Facebook
												.get_sessionState()
												.waitUntilReady(
														function() {
															var g = P.publicURL;
															FB.Connect
																	.showFeedDialog(
																			39319047083,
																			{
																				tn :L.value,
																				url :g
																			},
																			null,
																			null,
																			null,
																			FB.RequireConnect.promptConnect)
														})
									})
						});
				var U = new Button(
						"i",
						Y,
						"ttwitbut" + Q,
						"b",
						136,
						10,
						"Twitter",
						function() {
							var h = new Array();
							var l = 0;
							for ( var j in schmedley.widgets) {
								var g = schmedley.widgets[j];
								switch (g.type) {
								case "twitter":
									var k = g;
									l++;
									h.push(g);
									break
								}
							}
							if (l == 1 && k && k.input.value != "username") {
								k
										.setTweetText("i just published a new page using schmedley. check it out - "
												+ P.publicURL);
								k.twitterPost()
							} else {
								schmedley.blackOut("in");
								new Prompt(
										"Please enter your Twitter credentials...<br />",
										false,
										function(m) {
											var r = false;
											for ( var o = 0; o < h.length; o++) {
												var q = h[o];
												if (q.input.value = m[0].value) {
													if (!r) {
														q
																.setTweetText("i just published a new page using schmedley. check it out - "
																		+ P.publicURL);
														q.twitterPost();
														r = true
													} else {
														q.getPassword()
													}
												}
											}
											if (!r) {
												var n = "requestEnc.php";
												var p = new Request.JSON(
														{
															url :n,
															onComplete : function(
																	i) {
																if (i
																		&& i.status == "success") {
																	P
																			.postTweet(
																					m[0].value,
																					i.data.encValue)
																} else {
																	schmedley
																			.showError("There was an error dealing with the encryption of data.  Cannot proceed.")
																}
															}
														});
												p.send("v=" + m[1].value)
											}
											return true
										}, {
											username :false,
											password :true
										}, false)
							}
						});
				var f = new Button("i", Y, "tmailbut" + Q, "b", 358, 10,
						"Email", function() {
						});
				f.disable();
				f.el.addEvent("click", function() {
					alert(gls("tab9"))
				});
				function X() {
					var h = new Fx.Morph(A);
					C.enable();
					U.enable();
					$("tpubbut" + Q).getFirst().getNext().set("html",
							gls("but12"));
					var g = 410;
					var i = $("tpubbut" + Q).getFirst().getNext().clientWidth + 20;
					$("tpubbut" + Q).setStyle("left", (g - i) / 2 + "px");
					h.start( {
						top :"155px"
					}).chain( function() {
						schmedley.fade("in", B)
					})
				}
				function I() {
					var h = new Fx.Morph(A);
					C.disable();
					U.disable();
					$("tpubbut" + Q).getFirst().getNext().set("html",
							gls("but2"));
					var g = 410;
					var i = $("tpubbut" + Q).getFirst().getNext().clientWidth + 20;
					$("tpubbut" + Q).setStyle("left", (g - i) / 2 + "px");
					schmedley.fade("out", B, function() {
						h.start( {
							top :"55px"
						})
					})
				}
				var G = new Element("input", {
					type :"checkbox",
					name :"inSchpaces"
				}).setStyle("margin-right", "7px");
				if (this.indexTab == 1) {
					G.checked = true
				}
				var K = new Element("input", {
					type :"checkbox",
					name :"privacy"
				})
						.setStyle("margin-right", "7px")
						.addEvent(
								"click",
								function() {
									if (this.checked) {
										if (schmedley.isRegistered) {
											X();
											G.checked = true
										} else {
											this.checked = false;
											if (!schmedley.newTabRegConfirm) {
												schmedley.newTabRegConfirm = schmedley
														.showConfirm(
																gls("acp8")
																		+ "<br />&nbsp;<br />"
																		+ gls("acp1"),
																function() {
																	schmedley
																			.launchSignup();
																	P
																			.closeTabDialogs()
																},
																function() {
																	schmedley.newTabRegConfirm = null
																})
											}
										}
									} else {
										I()
									}
								});
				if (this.privacy == "public") {
					K.checked = true;
					X()
				} else {
					I()
				}
				D.adopt(new Element("div").adopt(K).appendText(gls("tab6")));
				d.adopt(B);
				D.adopt(new Element("div").setStyles( {
					"font-size" :"10px",
					"padding-left" :"22px",
					"font-style" :"italic",
					color :"#bccef1",
					"line-height" :"18px"
				}).appendText(gls("tab5")));
				var a = new Element("input", {
					type :"checkbox",
					name :"defaultTab"
				}).setStyle("margin-right", "7px");
				if (this.defaultTab == 1) {
					a.checked = true
				}
				B.adopt(new Element("div").adopt(new Element("div").setStyles( {
					"float" :"left"
				}).adopt(G)).adopt(new Element("div").setStyles( {
					"float" :"left",
					width :"350px",
					"line-height" :"18px"
				}).appendText(gls("tab8"))));
				B.adopt(new Element("div").setStyles( {
					clear :"left",
					"padding-top" :"8px",
					height :"20px"
				}).adopt(a).appendText(gls("tab7") + " - url..."));
				var R = new Element("div").setStyles( {
					"padding-left" :"4px"
				});
				function F(h) {
					var g = "http:..//" + location.host + "default.htm";
					g += schmedley.userName;
					if (!a.checked) {
						g += "./" + h
					}
					R.innerHTML = '<span style="color: #cf0; font-size: 13px; line-height: 30px;">'
							+ g + "</span>";
					P.publicURL = g
				}
				function J() {
					var h = L.value;
					var l = h.split(" ");
					var k = "";
					for ( var g = 0; g < l.length; g++) {
						if (g > 0) {
							var j = l[g].toLowerCase()
						} else {
							var j = l[g]
						}
						k += j
					}
					P.publicName = k;
					F(k)
				}
				J();
				B.adopt(R);
				if (this.privacy == "public") {
					B.setStyle("display", "block")
				}
				a.addEvent("click", function() {
					J()
				});
				if (!schmedley.isRegistered) {
					I()
				}
				this.showYellow(true);
				schmedley.addDialogClose(d, function() {
					P.showYellow(false)
				});
				schmedley.fade("in", d);
				this.manageDialog = d
			},
			publicCharOK : function(A, B) {
				return true
			},
			postTweet : function(G, D) {
				var A = this;
				var F = "i just published a new page using schmedley. check it out - "
						+ this.publicURL;
				var B = "http://schmedley.com/js/apps/twitter/tweet.php";
				var E = "un=" + G + "&epw=" + schmedley.escape64(D) + "&tweet="
						+ escape(F);
				var C = new Request.JSON( {
					url :B,
					onComplete : function() {
					}
				});
				C.send(E)
			},
			showYellow : function(A) {
				if (!this.tabi) {
					return
				}
				if (A) {
					this.tabi.set("class", "tabi_yellow")
				} else {
					if (this.privacy == "public") {
						this.tabi.set("class", "tabi_green")
					} else {
						this.tabi.set("class", "tabi_red")
					}
				}
			},
			removeTab : function() {
				if (!schmedley.canDeleteTab()) {
					schmedley.showError('<p style="text-align: center;">'
							+ gls("acp2") + "</p>");
					return false
				}
				var A = this;
				var D = schmedley.tabs[schmedley.tabs.length - 1];
				var C = schmedley.tabs[schmedley.tabs.length - 2];
				var E = $("tabs").getElementsByTagName("li")[0];
				this.closeButton.className = "xdown";
				var B = gls("acp3");
				if (this.isWidgetTab == 1) {
					B = gls("acp4") + "&nbsp;" + B
				}
				new Confirm(B, this.confirmRemoveTab.bindWithEvent(this),
						function() {
							A.closeButton.className = "tabx"
						})
			},
			confirmRemoveTab : function() {
				var A = this;
				var B = new Request.JSON( {
					url :"http://schmedley.com/js/removeTab.php",
					async :true,
					onComplete : function(C) {
						if (C && C.status == "success") {
							A.finishRemoveTab()
						} else {
							schmedley.showError("Failed to Delete Tab.");
							A.closeButton.className = "tabx"
						}
					}
				});
				B.get( {
					t :this.dbID
				})
			},
			finishRemoveTab : function() {
				this.desk.destroy();
				this.el.destroy();
				schmedley.removeTabRef(this);
				if (this.manageDialog) {
					this.manageDialog.destroy()
				}
				var B;
				for ( var A in schmedley.tabs) {
					B = schmedley.tabs[A];
					B.selectTab();
					break
				}
			},
			adjustTabFontColor : function() {
				var A = this.desk.el.getStyle("background-color");
				if (A == "transparent") {
					A = dfbg
				}
				var C = schmedley.colorIsLight(A);
				if (Browser.Engine.trident5 == true) {
					var B = $$("http://schmedley.com/js/li.dark");
					B.each( function(D) {
						D.removeClass("dark")
					})
				}
				if (C == true && this.desk.gradState != 1) {
					if (Browser.Engine.trident5 == true) {
						$("tab" + this.desk.dbID).addClass("dark")
					} else {
						$("tabs").addClass("dark")
					}
				} else {
					$("tabs").removeClass("dark")
				}
			},
			blinkDot : function() {
				if (schmedley.isDragging && !this.isActive && !this.blinkTimer) {
					this.blinkTimer = this.toggleDot.periodical(200, this);
					this.el.setOpacity(1)
				}
			},
			stopBlinkDot : function() {
				if (this.blinkTimer) {
					$clear(this.blinkTimer);
					delete this.blinkTimer;
					this.tabi.set("class", "tabi");
					this.el.setOpacity(0.4)
				}
			},
			toggleDot : function() {
				if (this.tabi.className == "tabi_blue") {
					this.tabi.set("class", "tabi")
				} else {
					this.tabi.set("class", "tabi_blue")
				}
			}
		});
var Button = new Class(
		{
			Extends :Object,
			initialize : function(K, B, A, E, G, F, H, J, D) {
				this.enabled = true;
				this.onClick = J;
				var C = new Element("div", {
					id :A,
					"class" :"but" + E
				});
				C
						.set(
								"html",
								'<div class="butl"></div><div class="butc">' + H + '</div><div class="butr"></div>');
				switch (K) {
				case "b":
					C.injectBefore(B);
					break;
				case "a":
					C.injectAfter(B);
					break;
				case "i":
					C.injectInside(B);
					break;
				case "t":
					C.injectTop(B);
					break
				}
				var I = this;
				C.setStyles( {
					display :"block",
					position :"absolute",
					height :"25px",
					overflow :"hidden",
					left :G + "px",
					top :F + "px"
				});
				C.addEvent("mousedown", function(L) {
					L = new Event(L).stop();
					if (I.enabled) {
						C.setProperty("class", E + "down")
					}
				});
				C.addEvent("mouseup", function(L) {
					L = new Event(L).stop();
					C.setProperty("class", "but" + E)
				});
				if ((D == false) || (D == "")) {
					C.addEvent("click", ( function(L) {
						L = new Event(L).stop();
						this.click()
					}).bindWithEvent(this))
				} else {
					C.addEvent("click", function(L) {
						L = new Event(L).stop();
						if (I.enabled && I.onClick) {
							I.onClick(D)
						}
					})
				}
				this.el = C
			},
			disable : function(A) {
				this.el.setStyle("opacity", 0.4);
				this.enabled = false
			},
			enable : function(A) {
				this.el.setStyle("opacity", 1);
				this.enabled = true
			},
			click : function() {
				if (this.enabled && this.onClick) {
					this.onClick()
				}
			},
			setText : function(B) {
				var A = this.el.getElement("http://schmedley.com/js/div.butc");
				A.set("html", B)
			}
		});
var Dock = new Class(
		{
			initialize : function() {
				this.dockBubble = "stuff";
				var A = window.getWidth();
				if (A <= 1024) {
					if (Browser.Engine.trident5 == true) {
						this.iconWidth = 32
					} else {
						this.iconWidth = 34
					}
					$("dock").setStyle("bottom", "7px")
				} else {
					this.iconWidth = 40
				}
				new Asset.images( [ "css/img/bubl.png", "css/img/bubc.png",
						"css/img/bubr.png", "css/img/bubb.png" ]);
				this.dock = $("dock");
				this.icons = this.dock.getElementsByTagName("img");
				for ( var C = 0; C < this.icons.length; C++) {
					this.icons[C].style.width = this.iconWidth + "px";
					this.icons[C].style.height = this.icons[C].style.width
				}
				this.dock.setStyle("display", "block");
				this.dockWidth = this.dock.offsetWidth;
				this.refreshDockDisplay();
				this.dock.style.marginLeft = -parseInt(this.dock.offsetWidth / 2)
						+ "px";
				this.dock.addEvent("mousemove", this.mousemoveDock
						.bindWithEvent(this));
				this.dock.addEvent("mouseout", this.mouseoutDock
						.bindWithEvent(this));
				this.bubble = new Element("div", {
					id :"dockBubble",
					"class" :"bubble",
					opacity :0
				});
				this.bubble
						.set(
								"html",
								'<div class="bubl"></div><div class="bubc"></div><div class="bubr"></div><div class="bubb"></div>');
				this.bubble.injectInside(document.body);
				var B = this;
				$$("#dock img").addEvent("mouseenter", function(D) {
					D = new Event(D).stop();
					B.dockIcon = this.id
				});
				schmedley.fade("in", this.dock)
			},
			schedule : function(C, B, A) {
				if (A == null) {
					A = 0
				}
				if (C == "window") {
					window.addEvent("domready", B)
				} else {
					if ($(C)) {
						B()
					} else {
						if (A < 300) {
							setTimeout( function() {
								schedule(C, B, A + 1)
							}, 10)
						}
					}
				}
				return true
			},
			refreshDockDisplay : function() {
				this.dock.style.marginLeft = -parseInt(this.dock.offsetWidth / 2)
						+ "px";
				return true
			},
			mousemoveDock : function(H) {
				var I = new Event(H);
				var K = this.dock;
				if (typeof K.relaxTimer != "undefined") {
					clearTimeout(K.relaxTimer)
				}
				if (typeof this.originalWidth == "undefined") {
					this.originalLeft = K.offsetLeft;
					this.originalWidth = K.offsetWidth
				}
				var B = I.client.x - this.originalLeft;
				var A = 64;
				var C = 3;
				var F = parseInt(B / this.iconWidth);
				var J = this.icons;
				var E = this.iconWidth;
				if (F > J.length - 1) {
					F = J.length - 1
				}
				for ( var D = 0; D < this.icons.length; D++) {
					this.icons[D].style.width = this.iconWidth + "px";
					this.icons[D].style.height = this.icons[D].style.width
				}
				for ( var D = F - 1; D > -1 && D > F - C; D--) {
					var G = (1 - ((B - ((D + 1) * this.iconWidth)) / (C * this.iconWidth)))
							* A;
					if (G > 1) {
						this.icons[D].style.width = Math.round(G) + "px"
					}
					if (parseInt(J[D].style.width) < this.iconWidth) {
						this.icons[D].style.width = this.iconWidth + "px"
					}
					this.icons[D].style.height = J[D].style.width;
					this.moveBubble()
				}
				for ( var D = F + 1; D < J.length && D < F + C && D > -1; D++) {
					J[D].style.width = (1 - (((D * E) - B) / (C * E))) * A
							+ "px";
					if (parseInt(J[D].style.width) < E) {
						J[D].style.width = E + "px"
					}
					J[D].style.height = J[D].style.width;
					this.moveBubble()
				}
				if (F < J.length && F > -1) {
					J[F].style.width = A + "px";
					J[F].style.height = A + "px";
					this.moveBubble()
				}
				this.refreshDockDisplay();
				return true
			},
			mouseoutDock : function(A) {
				this.dock.relaxTimer = this.relaxDock.bindWithEvent(this)
						.delay(50);
				this.hideBubble();
				return true
			},
			relaxDock : function() {
				var B = 1;
				var D = true;
				for ( var C = 0; C < this.icons.length; C++) {
					var A = parseInt(this.icons[C].style.width);
					if (A >= this.iconWidth + B) {
						D = false;
						this.icons[C].style.width = A - B + "px";
						this.icons[C].style.height = this.icons[C].style.width
					}
				}
				this.refreshDockDisplay();
				if (!D) {
					this.dock.relaxTimer = this.relaxDock.bindWithEvent(this)
							.delay(25)
				}
				return true
			},
			moveBubble : function() {
				var C = this.bubble.getElementsByTagName("div")[1].clientWidth + 10;
				var B = $(this.dockIcon);
				if (!B) {
					this.hideBubble();
					return
				}
				var D = (B.offsetLeft + this.dock.offsetLeft + 32 - (C / 2))
						.round();
				var A = this.bubble.getElement("div.bubc");
				if (Browser.Engine.trident5 == true) {
					this.bubble.getElementsByTagName("div")[3].style.width = C
							+ "px"
				}
				this.bubble.setStyle("left", D + "px");
				this.bubble.setStyle("opacity", 1);
				A.set("html", B.alt)
			},
			hideBubble : function() {
				this.bubble.setStyle("opacity", 0)
			},
			show : function() {
				this.dock.setStyle("display", "block")
			},
			hide : function() {
				this.dock.setStyle("display", "none");
				this.hideBubble()
			}
		});