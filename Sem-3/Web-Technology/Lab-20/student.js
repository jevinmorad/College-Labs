const express = require("express")
const mongoose = require("mongoose")
const bodyParse = require("body-parser")
const Student = require("./Schema")

mongoose.connect("mongodb+srv://Darshan:diet23010101171@cluster0.q2pxy.mongodb.net/")
    .then(() => {
        const app = express();
        app.use(bodyParse.urlencoded())

        
        // create
        app.post('/student', async (req, res) => {
            stu = new Student({...req.body})
            const ans = await stu.save();
            res.send(ans);
        })
        
        // get all
        app.get('/student', async (req, res) => {
            const data = await Student.find()
            res.send(data)
        })

        // get by name

        app.get('/student/:name', async (req,res,next) => {
            const ans = await Student.find({
                name: {
                    $regex:req.params.name
                }
            })
            console.log(ans);
            if (ans!=null) {
                res.send(ans)
            }else {
                next()
            }
        })
        // get by enrollment
        app.get('/student/:enrollment', async (req,res) => {
            const ans = await Student.findOne({enrollment:req.params.enrollment});
            res.send(ans)
        })

        // update 
        app.patch('/student/:enrollment', async (req, res) => {
            stu = await Student.findOne({enrollment:req.params.enrollment})
            stu.name = req.body.name;
            const ans = await stu.save();
            res.send(ans)
        })

        // delete
        app.delete('/student/:enrollment', async (req,res) => {
            ans = await Student.deleteOne({enrollment:req.params.enrollment})
            res.send(ans)
        })

        app.listen(3000, () => {
            console.log("Server started");
        })
    })