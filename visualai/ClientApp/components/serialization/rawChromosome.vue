<template>
    <div>
        <h4>Raw chromosomes</h4>
        <div class="chromosome"><code>{{ actiFunctions }}</code></div>
        <div class="chromosome"><code>{{ connectionPresence }}</code></div>
        <div class="chromosome"><code>{{ weightsBinary }}</code></div>
    </div>
</template>
<script>
    export default {
        props: ['rawData'],
        computed: {
            actiFunctions: function () {
                if (!this.rawData.actiFunctions) return '';
                return this.rawData.actiFunctions.join(' ');
            },
            connectionPresence: function () {
                if (!this.rawData.connectionPresence) return '';
                return this.rawData.connectionPresence.join(' ');
            },
            weightsBinary: function () {
                if (!this.rawData.weightsBinary) return '';
                return this.rawData.weightsBinary.join(' ');
            }
        }
    }
</script>
<style scoped>
    .chromosome{
        margin: 10px 0;
    }
</style>