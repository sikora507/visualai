<template>
    <div class="function">
        <h3>{{name}}</h3>
        <button class="btn btn-default" @click="computeFunction">
            Compute
        </button>
        <div class="preview">
            <canvas id="canv"></canvas>
        </div>
    </div>
</template>
<script>
    import Vue from 'vue';

    export default {
        props: ['name'],
        data: function () {
            return {

            }
        },
        methods: {
            computeFunction: function () {
                alert('computing');
            }
        },
        mounted: function () {
            var c = this.$el.getElementsByTagName('canvas')[0];
            var ctx = c.getContext("2d");
            var width = c.offsetWidth;
            var height = c.offsetHeight;
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
    }
</script>
<style scoped>
    .function {
        position: relative;
        text-align: center;
        width: 400px;
        margin-bottom: 20px;
        border: 1px solid black;
        border-radius: 10px;
        overflow: hidden;
    }
    .preview {
        background-color: cornsilk;
        flex-grow: 0;
        height: 170px;
    }

    button {
        position: absolute;
        top: 15px;
        right: 15px;
    }
    canvas{
        background-color: white;
        width: 350px;
        height: 150px;
        margin-top:10px;
    }
</style>