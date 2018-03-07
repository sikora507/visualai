<template>
    <canvas></canvas>
</template>
<script>
    import Vue from 'vue';

    function clearCanvas() {
        ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
        ctx.canvas.width = width;
        ctx.canvas.height = height;
        ctx.translate(0.5, 0.5)
        ctx.setLineDash([4, 8]);
        ctx.beginPath();
        ctx.moveTo(0, height / 2);
        ctx.lineTo(width, height / 2);
        ctx.moveTo(width / 2, 0);
        ctx.lineTo(width / 2, height);
        ctx.stroke();
    }
    var ctx = null;
    var width = 0;
    var height = 0;
    export default {
        // data comes in x and y points
        props: ['width', 'height', 'points'],
        data: function() {
            return {

            }
        },
        mounted: function () {
            var c = this.$el;
            c.width = this.width;
            c.height = this.height;
            width = this.width;
            height = this.height;
            ctx = c.getContext("2d");
            clearCanvas();
        },
        watch: {
            data: function (val) {
                clearCanvas();
                console.log('Chart - got data:');
                console.log(val);
            }
        }
    }
</script>
<style scoped>
    canvas {
        background-color: white;
        margin: 10px;
    }
</style>