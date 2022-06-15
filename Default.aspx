<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<link rel="stylesheet" type="text/css" href="css/index-style.css" />
	<link rel="stylesheet" type="text/css" href="css/flickity.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
	<div class="middle-top">
		<img src="img/bannerwrpflickity.png" class="bannerwrpflickity flktywrpimg"/>
		<img src="img/flickitykid1.png" class="flickitykid1 flktywrpimg"/>
		<img src="img/flickitykid2.png" class="flickitykid2 flktywrpimg"/>
		<img src="img/flickitykid3.png" class="flickitykid3 flktywrpimg"/>
		<img src="img/flickitykid4.png" class="flickitykid4 flktywrpimg"/>
		<img src="img/flickitykid5.png" class="flickitykid5 flktywrpimg"/>
		<div class="flickity-wrapper">
			<div class="gallery" data-flickity='{ "autoPlay": true }'>
				<div class="gallery-cell">
					<img src="img/banners/longbanners/longban7.jpg"/>
				</div>
				<div class="gallery-cell">
					<img src="img/banners/longbanners/longban6.jpg"/>
				</div>
				<div class="gallery-cell">
					<img src="img/banners/longbanners/longban5.jpg"/>
				</div>
				<div class="gallery-cell">
					<img src="img/banners/longbanners/longban4.jpg"/>
				</div>
				<div class="gallery-cell">
					<img src="img/banners/longbanners/longban3.jpg"/>
				</div>
				<div class="gallery-cell">
					<img src="img/banners/longbanners/longban2.jpg"/>
				</div>
				<div class="gallery-cell">
					<img src="img/banners/longbanners/longban1.jpg"/>
				</div>
				<div class="gallery-cell">
					<img src="img/banners/longbanners/longban4.jpg"/>
				</div>
			</div>
		</div>
	</div>
	<div class="middle-top-container">
		<div class="longestban-wrp">
			<div class="banner-hover">Buraya biraz yazı</div>
			<img src="img/banners/longbanners/longban2.jpg" class="longestban">
		</div>
    </div>
	<div class="middle-container">
		<div class="content-row">
            <div class="content-col content-col-1">
			    <div class="trio-wrp col-top">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/shortbanners/shortban6.jpg" class="shortbans">
			    </div>
			    <div class="trio-wrp col-bot">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/shortbanners/shortban2.jpg" class="shortbans">
			    </div>
            </div>
            <div class="content-col content-col-2">
			    <div class="trio-wrp trio-mid-wrp">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/verticalbanners/verticalban1.jpg" class="shortbans">
			    </div>
            </div>
            <div class="content-col">
			    <div class="trio-wrp col-top">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/shortbanners/shortban7.jpg" class="shortbans">
			    </div>
			    <div class="trio-wrp col-bot">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/shortbanners/shortban1.jpg" class="shortbans">
			    </div>
            </div>
		</div>
        
		<div class="content-row">
            <div class="content-col content-col-1">
			    <div class="trio-wrp col-top">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/shortbanners/shortban3.jpg" class="shortbans">
			    </div>
			    <div class="trio-wrp col-bot">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/shortbanners/shortban4.jpg" class="shortbans">
			    </div>
            </div>
            <div class="content-col content-col-2">
			    <div class="trio-wrp trio-mid-wrp">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/verticalbanners/verticalban2.jpg" class="shortbans">
			    </div>
            </div>
            <div class="content-col">
			    <div class="trio-wrp col-top">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/shortbanners/shortban5.jpg" class="shortbans">
			    </div>
			    <div class="trio-wrp col-bot">
				    <div class="banner-hover">Buraya biraz yazı</div>
				    <img src="img/banners/shortbanners/shortban1.jpg" class="shortbans">
			    </div>
            </div>
		</div>

	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomJSPlaceHolder" Runat="Server">
    <script type="text/javascript" src="js/flickity.pkgd.js"></script>
    <script type="text/javascript">
        $(function () {
            var $gallery = $('.gallery').flickity({
                cellSelector: '.gallery-cell'
            })
        });
    </script>
</asp:Content>

