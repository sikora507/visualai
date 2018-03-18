<template>
    <div>
        <h2>Network serialization to genome</h2>
        <div class="row">
            <div class="col-md-5">
                <simple-network></simple-network>
            </div>
            <div class="col-md-7">

            </div>
        </div>
    </div>
</template>
<script>
    import SimpleNetwork from '../simpleNetwork/simpleNetwork.vue';

    export default {
        components: {
            'simple-network': SimpleNetwork
        }
    }
</script>
<style>

</style>