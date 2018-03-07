<template>
    <div class="function">
        <h3>{{name}}</h3>
        <button class="btn btn-default" @click="computeFunction">
            Compute
        </button>
        <div class="preview">
            <chart width="350" height="170" :points="chartData"></chart>
        </div>
    </div>
</template>
<script>
    import Vue from 'vue';
    import Chart from './chart.vue';

    export default {
        props: ['name', 'action'],
        data: function () {
            return {
                chartData: ''
            }
        },
        methods: {
            computeFunction: function () {
                this.chartData = null;
                fetch(`api/ActivationFunctions/${this.action}`)
                    .then(response => response.json())
                    .then(data => {
                        this.chartData = data;
                    });
            }
        },
        components: {
            'chart': Chart
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
    }
    button {
        position: absolute;
        top: 15px;
        right: 15px;
    }
</style>