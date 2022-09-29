<template>
    <div class="column is-4-desktop is-6-tablet" @click="openAuction()">
        <div class="card is-rounded">
            <div class="card-content  p-0">
                <div class="content" style="margin-bottom: -1rem; height: 22rem;">
                    <img :src="INFO.image" alt="" style="max-height: 25rem;width: 100%;object-fit: cover;">
                </div>
            </div>
            <div class="card-footer has-background-info-light">
                <div class="card-footer-item">
                    <div class="columns is-mobile is-multiline">
                        <div class="column is-12">
                            <h4 class="title">{{INFO.name}}</h4>
                        </div>
                        <div class="column is-6">
                            <p class="mb-2" style="font-size:12px;">Окончание аукциона</p><span
                                class="tag is-danger is-light"
                                style="font-size:12px;">{{INFO.timeEnd}}</span>
                        </div>
                        <div class="column is-6">
                            <p class="mb-2" style="font-size:12px;">Лучшая ставка</p><span
                                class="tag is-success is-light" style="font-size:12px;">{{MAX_STAVKA}} Р.</span>
                        </div>
                        <div class="column is-12 button is-primary is-light" @click="openAuction()">
                            Сделать ставку
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
    
<script>
export default {
    props: {
        auction: null
    },
    components: {},
    computed: {
        INFO: function (){
            return this.auction.auctionInfo;
        },
        HISTORY: function (){
            return this.auction.listStavka;
        },
        MAX_STAVKA: function () {
            return this.HISTORY.reduce((a, b) => { 
                return {size: Math.max(a.size, b.size)};
            }, {size:this.INFO.startStavka}).size;
        }
    },
    methods: {
        openAuction: function () {
            this.$router.push({ name: 'auction', query: { id: this.INFO.id } })
        },
    },
    mounted() { }
}
</script>
    
<style lang='scss' scoped>

    .card {
      box-shadow: none;
      border-radius: 1rem;
      overflow: hidden;
      transition: all .2s ease;
    }
    .card:hover{
        cursor: pointer;
        box-shadow: 0 0.5em 1em -0.125em rgba(10, 10, 10, 0.1), 0 0px 0 1px rgba(10, 10, 10, 0.02);
        transform: scale(1.01);
    }
</style>
    