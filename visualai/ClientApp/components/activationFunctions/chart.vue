<template>
    <canvas></canvas>
</template>
<script>
    import Vue from 'vue';
    // initialization in mounted callback

    function clearCanvas(ctx) {
        ctx.translate(-0.5, -0.5);
        ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
        ctx.translate(0.5, 0.5);
        ctx.setLineDash([4, 8]);
        ctx.beginPath();
        ctx.moveTo(0, ctx.canvas.height / 2);
        ctx.lineTo(ctx.canvas.width, ctx.canvas.height / 2);
        ctx.moveTo(ctx.canvas.width / 2, 0);
        ctx.lineTo(ctx.canvas.width / 2, ctx.canvas.height);
        ctx.stroke();
        ctx.closePath();
    }

    function drawLine(points, ctx) {
        if (!points || !points.length) {
            return;
        }
        var minX = -10; // [-10 ; 10]
        var maxX = 10;
        var minY = -1; // [-1 ; 1]
        var maxY = 1; 
        var lengthX = maxX - minX;
        var lengthY = maxY - minY;
        var ratioX = ctx.canvas.width / lengthX;
        var ratioY = ctx.canvas.height / lengthY;
        var halfWidth = ctx.canvas.width / 2;
        var halfHeight = ctx.canvas.height / 2;
        ctx.beginPath();
        ctx.setLineDash([]);
        for (let i = 0; i < points.length; i += 2) {
            let scalledX = (ratioX * points[i]) + halfWidth;
            let scalledY = halfHeight - (ratioY * points[i + 1]);
            if (i < 2) {
                ctx.moveTo(scalledX, scalledY);
            } else {
                ctx.lineTo(scalledX, scalledY);
            }
        }
        ctx.stroke();
        ctx.closePath();
    }

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
            this.ctx = c.getContext("2d");
            this.ctx.canvas.width = this.width;
            this.ctx.canvas.height = this.height;
            this.ctx.translate(0.5, 0.5);
            clearCanvas(this.ctx);
        },
        watch: {
            points: function (val) {
                if (!val) {
                    return;
                }
                clearCanvas(this.ctx);
                console.log('Chart - got data:');
                console.log(val);
                drawLine(val, this.ctx);
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