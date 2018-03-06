<template>
    <div class="function">
        <h3>{{name}}</h3>
        <button class="btn btn-default">Compute</button>
        <div class="preview"></div>
    </div>
</template>
<script>
    import Vue from 'vue';

    export default {
        props: ['name'],
        data: function () {
            return {

            }
        }
    }
</script>
<style>
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
</style>