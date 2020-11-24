//using system.collections;
//using system.collections.generic;
//using unityengine;

//public class swordman : playercontroller
//{



//    private void start()
//    {

//        m_capsullecollider = this.transform.getcomponent<capsulecollider2d>();
//        m_anim = this.transform.find("model").getcomponent<animator>();
//        m_rigidbody = this.transform.getcomponent<rigidbody2d>();


//    }



//    private void update()
//    {



//        checkinput();

//        if (m_rigidbody.velocity.magnitude > 30)
//        {
//            m_rigidbody.velocity = new vector2(m_rigidbody.velocity.x - 0.1f, m_rigidbody.velocity.y - 0.1f);

//        }




//    }

//    public void checkinput()
//    {



//        if (input.getkeydown(keycode.s))  //아래 버튼 눌렀을때. 
//        {

//            issit = true;
//            m_anim.play("sit");


//        }
//        else if (input.getkeyup(keycode.s))
//        {

//            m_anim.play("idle");
//            issit = false;

//        }


//        sit나 die일때 애니메이션이 돌때는 다른 애니메이션이 되지 않게 한다.
//        if (m_anim.getcurrentanimatorstateinfo(0).isname("sit") || m_anim.getcurrentanimatorstateinfo(0).isname("die"))
//        {
//            if (input.getkeydown(keycode.space))
//            {
//                if (currentjumpcount < jumpcount)  // 0 , 1
//                {
//                    downjump();
//                }
//            }

//            return;
//        }


//        m_movex = input.getaxis("horizontal");



//        groundcheckupdate();


//        if (!m_anim.getcurrentanimatorstateinfo(0).isname("attack"))
//        {
//            if (input.getkey(keycode.mouse0))
//            {


//                m_anim.play("attack");
//            }
//            else
//            {

//                if (m_movex == 0)
//                {
//                    if (!oncejumpraycheck)
//                        m_anim.play("idle");

//                }
//                else
//                {

//                    m_anim.play("run");
//                }

//            }
//        }


//        if (input.getkey(keycode.alpha1))
//        {
//            m_anim.play("die");

//        }

//        기타 이동 인풋.

//        if (input.getkey(keycode.d))
//        {

//            if (isgrounded)  // 땅바닥에 있었을때. 
//            {



//                if (m_anim.getcurrentanimatorstateinfo(0).isname("attack"))
//                    return;

//                transform.transform.translate(vector2.right * m_movex * movespeed * time.deltatime);



//            }
//            else
//            {

//                transform.transform.translate(new vector3(m_movex * movespeed * time.deltatime, 0, 0));

//            }




//            if (m_anim.getcurrentanimatorstateinfo(0).isname("attack"))
//                return;

//            if (!input.getkey(keycode.a))
//                filp(false);


//        }
//        else if (input.getkey(keycode.a))
//        {


//            if (isgrounded)  // 땅바닥에 있었을때. 
//            {



//                if (m_anim.getcurrentanimatorstateinfo(0).isname("attack"))
//                    return;


//                transform.transform.translate(vector2.right * m_movex * movespeed * time.deltatime);

//            }
//            else
//            {

//                transform.transform.translate(new vector3(m_movex * movespeed * time.deltatime, 0, 0));

//            }


//            if (m_anim.getcurrentanimatorstateinfo(0).isname("attack"))
//                return;

//            if (!input.getkey(keycode.d))
//                filp(true);


//        }


//        if (input.getkeydown(keycode.space))
//        {
//            if (m_anim.getcurrentanimatorstateinfo(0).isname("attack"))
//                return;


//            if (currentjumpcount < jumpcount)  // 0 , 1
//            {

//                if (!issit)
//                {
//                    prefromjump();


//                }
//                else
//                {
//                    downjump();

//                }

//            }


//        }



//    }





//    protected override void landingevent()
//    {


//        if (!m_anim.getcurrentanimatorstateinfo(0).isname("run") && !m_anim.getcurrentanimatorstateinfo(0).isname("attack"))
//            m_anim.play("idle");

//    }





//}
