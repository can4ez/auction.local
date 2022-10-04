<template>
    <div class="column is-4-desktop is-6-tablet" @click="openAuction()">
        <div class="card is-rounded">
            <div class="card-content  p-0">
                <div class="content" style="margin-bottom: -1rem; height: 22rem;">
                    <img :src="INFO.image" alt="" class="card__img" style="">
                </div>
            </div>
            <div class="card-footer has-background-info-light">
                <div class="card-footer-item">
                    <div class="columns is-mobile is-multiline">
                        <div class="column is-12">
                            <h4 class="title">[{{USER_NAME}}] {{INFO.name}}</h4>
                        </div>
                        <div class="column is-6">
                            <p class="mb-2" style="font-size:12px;">Окончание аукциона</p><span
                                class="tag is-danger is-light"
                                style="font-size:12px;">{{OUT_DATE}}</span>
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
    import { mapGetters } from 'vuex'; 
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
        },

        OUT_DATE: function () {
  let time = Number(this.INFO.timeEnd) - new Date();
  if(time < 0 || isNaN(time)){  return "Завершен"; }

  var delta = time / 1000;
  var days = Math.floor(delta / 86400);
  delta -= days * 86400;
  var hours = Math.floor(delta / 3600) % 24;
  delta -= hours * 3600;
  var minutes = Math.floor(delta / 60) % 60;
  delta -= minutes * 60;
  var seconds = Math.floor(delta) % 60;

  var result = "";

  if(days > 0) result = result + " " + days + " д.";
  if(hours > 0) result = result + " " + hours + " ч."; 
  if(minutes > 0) result = result + " " + minutes + " м.";
  if(seconds > 0) result = result + " " + seconds + " с.";


  return result;
},

USER_NAME: function () { 
    return this.USERS.find(e => {
         return e.id == this.INFO.idUser;
    }).name;
},
    ...mapGetters('users', ['USERS']),
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
.card__img{
    max-height: 100%;
    width: 100%;
    height: 100%;
    object-fit: cover;
}
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
    