<template>

<div :class="uniqName + '-group group'">

<div class="field" v-if="inputType == 'select'">
  <label class="label">{{legend}}</label>
  <p class="control">
    <span class="select">
      <select 
      :name="uniqName" 
      :id="uniqName"
      @input="onchange($event)"
      v-model="data">
        <option v-for="row in options" :value="row.value">{{row.text}}</option>
      </select>
    </span>
  </p>
</div>

<div class="field" v-else-if="inputType != 'select'" >
  <label class="label ">{{legend}}</label>
  <div class="field has-addons " v-for="row in options">
  <div class="field-label is-normal">
    <label class="label ">{{row.text}}</label>
  </div>
    <div class="control">
      <input class="input" 
              :type="inputType"
              @change="onchange($event)"  
              v-model="data"
      >
      <!-- 
              :value="(row.value !== undefined && !valueAsPlaceholder) ? row.value : ''"
              :placeholder="(row.value !== undefined && valueAsPlaceholder) ? row.value : ''"
             -->
    </div>
  </div>
</div>

</div>
</template>

<script>
export default {
  props: {
    uniqName: { default: '' },
    inputType: { default: 'text' },
    legend: { default: '' },
    options: { default: [] },
    valueAsPlaceholder: { default: false },
  },
  data () {
    return {
      data: null
    }
  },
  components: { },
  computed: {

  },
  methods: {

    CLASSES: function (){
      return {
        'filter-group': true
      }
    },
    onchange: function (event) {
      this.$emit('onchange' , this.data);
    }

  },
  mounted () { }
}
</script>

<style lang='scss'>
  .group{
    margin-top: 1rem;
  }
  .is-normal{
    text-align: right;
  }
  .legend{}
  .body{}
  .row{}
  label{}
  input{}
  .field-label{
    flex-grow: 0 !important;
  }
</style>
