<template>
    <section>
        <h1>Activation functions</h1>
        <div class="flex">
            <preview name="Sigmoid" action="GetSigmoid"></preview>
            <preview name="TanH" action="GetTanh"></preview>
            <preview name="Gauss" action="GetGauss"></preview>
            <preview name="Sin" action="GetSine"></preview>
        </div>
    </section>
</template>
<script>
    import Vue from 'vue';
    import PreviewComponent from './previewcomponent.vue'
    export default {
        data: function () {
            return {

            }
        },
        components: {
            'preview': PreviewComponent
        }
    }
</script>
<style scoped>
    .flex {
        display: flex;
        justify-content: space-evenly;
        flex-direction: row;
        flex-wrap: wrap;
        width: 100%;
    }
</style>