$.fn.hint = function(){
	var that = this;
	that.each(function(index,elem){
		var $this = $(this);
		$this.val($this.attr('hint'))
			.addClass('hint')
			.focus(function(){
				var $this = $(this);
				var hintText = $this.attr("hint");
				if ($this.val() === hintText){
					$this.val('').removeClass("hint");
				}
			})
			.blur(function(){
				var $this = $(this);
				var hintText = $this.attr("hint");
				if ($this.val() === ''){
					$this.val(hintText).addClass("hint");
				}
			});
	});
}