<template>
    <section>
        <h1>Activation functions</h1>
        <div class="flex">
            <preview name="Sigmoid"></preview>
            <preview name="TanH"></preview>
            <preview name="Gauss"></preview>
            <preview name="Sin"></preview>
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