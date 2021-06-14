using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WF {
    public class SimpleComponent {
        private SimpleComponent m_parent;
        public List<SimpleComponent> m_childList;

        public virtual bool initialize() {
            return true;
        }

        public virtual void update() {
            if (m_childList != null) {
                List<SimpleComponent> p_tempChildList = new List<SimpleComponent>(m_childList);
                foreach (SimpleComponent comp in p_tempChildList) {
                    comp.update();
                }
            }
        }

        public virtual void terminate() {
            removeAllChild(true);
        }

        //增加子节点
        public void addComponent(SimpleComponent addComp) {
            if (m_childList == null)
                m_childList = new List<SimpleComponent>();
            addComp.setParent(this);
            m_childList.Add(addComp);
        }

        //根据对象删除子节点
        public void removeComponent(SimpleComponent removeComp, bool isTermainate = true/*是否调用子节点的销毁函数 进行一些释放之类的*/) {
            if (isTermainate)
                removeComp.terminate();
            if (m_childList == null)
                return;
            m_childList.Remove(removeComp);
        }

        public void setParent(SimpleComponent comp) {
            m_parent = comp;
        }
        public SimpleComponent getParent() {
            return m_parent;
        }

        //根据位置删除子节点
        public void removeChildByIndex(int index, bool isTermainate = true) {
            if (m_childList == null) {
                return;
            }
            if (m_childList.Count <= index) {
                return;
            }
            SimpleComponent removeComp = m_childList[index];
            removeComponent(removeComp, isTermainate);
        }

        //移除所有子节点
        public void removeAllChild(bool isTermainate = true) {
            if (m_childList == null) {
                return;
            }
            while (m_childList.Count > 0) {
                if (isTermainate) {
                    SimpleComponent pComp = m_childList[0];
                    pComp.terminate();
                }
                m_childList.RemoveAt(0);
            }
        }

        //移除自己 移除自己后，一般是没有被引用了，此对象进入GC isTermainate true为执行Termainate函数,进行一些释放之类的
        public void removeFromParent(bool isTermainate = true) {
            if (m_parent != null) {
                m_parent.removeComponent(this, isTermainate);
            }
        }

        //根据泛型寻找某个子节点
        public T findComponent<T>() {
            if (m_childList == null) {
                return default;
            }
            foreach (SimpleComponent child in m_childList) {
                if (child is T) {
                    return (T)(object)child;
                }
            }
            return default;
        }
        //根据索引寻找子节点
        public SimpleComponent findComponentByIndex(int index) {
            if (m_childList == null) {
                return null;
            }
            if (m_childList.Count <= index) {
                return null;
            }
            return m_childList[index];
        }
    }
}
