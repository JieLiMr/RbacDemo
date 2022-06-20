<template>
    <div>
          <el-table
    :data="tableData"
    style="width: 100%;margin-bottom: 20px;"
    row-key="menuId"
    border
    default-expand-all
    :tree-props="{children: 'children', hasChildren: 'hasChildren'}">
    <el-table-column
      prop="menuId"
      label="编号"
      sortable
      width="180">
    </el-table-column>
    <el-table-column
      prop="menuName"
      label="菜单名称"
      sortable
      width="180">
    </el-table-column>
 
  </el-table>
    </div>
</template>

<script>
export default {
data()
{
    return {
        tableData:[]
    }
}   
    ,methods:{
        showInfor()
        {
            this.$axios.get("https://localhost:44349/api/MenuManger/getAll").then
            (
                res=>{
                    this.tableData=res.data;
                    console.log(this.tableData)
                }
                
            )
        }

    },created()
    {
        this.showInfor();
    }
}
</script>