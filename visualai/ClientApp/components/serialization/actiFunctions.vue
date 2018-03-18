<template>
    <div>
        <h4>Neurons activation functions</h4>
        <span class="badge badge-info" v-for="item in data">{{ item }}</span>
    </div>
</template>
<script>
    export default {
        props: ['data']
    }
</script>
<style scoped>
    .badge-info {
        background-color: #3a87ad;
    }
</style>